using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurnBuilder.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BurnBuilder.DAL
{
    public class DALDeckCard
    {
        private readonly IConfiguration configuration;

        public DALDeckCard(IConfiguration config)
        {
            this.configuration = config;
        }

        internal int InsertDeckCard(DeckCard deckCard)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "INSERT INTO [dbo].[DeckCard]([CardID],[DeckID],[CardQuantity]) VALUES(@CardID,@DeckID,@CardQuantity) select SCOPE_IDENTITY() as id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CardID", deckCard.CardId);
            cmd.Parameters.AddWithValue("@DeckID", deckCard.DeckId);
            cmd.Parameters.AddWithValue("@CardQuantity", deckCard.CardQuantity);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int id = Convert.ToInt32(reader[0].ToString());

            reader.Close();

            conn.Close();

            return id;
        }

        internal DeckCard GetDeckCardByID(int deckCardId)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "SELECT [CardID],[DeckID],[CardQuantity] FROM [dbo].[DeckCard] WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", deckCardId);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int cardId = Convert.ToInt32(reader["CardID"].ToString());
            int deckId = Convert.ToInt32(reader["DeckID"].ToString());
            int cardQuantity = Convert.ToInt32(reader["CardQuantity"].ToString());

            reader.Close();

            conn.Close();

            DeckCard dC = new DeckCard();
            dC.CardId = cardId;
            dC.DeckId = deckId;
            dC.CardQuantity = cardQuantity;

            return dC;
        }

        internal DeckCard UpdateDeckCard(DeckCard deckCard)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query =
                "UPDATE [dbo].[DeckCard] SET [CardID] = @CardID, [DeckID] = @DeckID, [CardQuantity] = @CardQuantity WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CardID", deckCard.CardId);
            cmd.Parameters.AddWithValue("@DeckID", deckCard.DeckId);
            cmd.Parameters.AddWithValue("@CardQuantity", deckCard.CardQuantity);

            cmd.ExecuteNonQuery();

            conn.Close();

            DeckCard dC = new DeckCard();

            return dC;
        }

        internal void DeleteDeckCard(int id)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query =
                "DELETE [dbo].[DeckCard] WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
