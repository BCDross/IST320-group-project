using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurnBuilder.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BurnBuilder.DAL
{
    public class DALDeck
    {
        private readonly IConfiguration configuration;

        public DALDeck(IConfiguration config)
        {
            this.configuration = config;
        }

        internal int InsertDeck(Deck deck)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "INSERT INTO [dbo].[Deck]([CreatorUserID],[DeckName],[Created],[Description],[DeckColor])" +
                           " VALUES(@CreatorUserID,@DeckName,@Created,@Description,@DeckColor) select SCOPE_IDENTITY() as id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CreatorUserID", deck.CreatorUserId);
            cmd.Parameters.AddWithValue("@DeckName", deck.DeckName);
            cmd.Parameters.AddWithValue("@Created", deck.Created);
            cmd.Parameters.AddWithValue("@Description", deck.Description);
            cmd.Parameters.AddWithValue("@DeckColor", deck.DeckColor);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int deckId = Convert.ToInt32(reader[0].ToString());

            reader.Close();

            conn.Close();

            return deckId;
        }

        internal Deck GetDeckByID(int deckId)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "SELECT [CreatorUserID],[DeckName],[Created],[Description],[DeckColor] FROM [dbo].[Deck] WHERE DeckID = @DeckID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DeckID", deckId);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int creatorUserId = Convert.ToInt32(reader["CreatorUserID"].ToString());
            string deckName = reader["DeckName"].ToString();
            DateTime created = Convert.ToDateTime(reader["Created"].ToString());
            string description = reader["Description"].ToString();
            string deckColor = reader["DeckName"].ToString();

            reader.Close();

            conn.Close();

            Deck d = new Deck();
            d.CreatorUserId = creatorUserId;
            d.DeckName = deckName;
            d.Created = created;
            d.Description = description;
            d.DeckColor = deckColor;

            return d;
        }

        internal Deck UpdateDeck(Deck deck)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query =
                "UPDATE [dbo].[Deck] SET [CreatorUserID] = @CreatorUserID,[DeckName] = @DeckName,[Created] = @Created,[Description] = @Description,[DeckColor] = @DeckColor WHERE [DeckID] = @DeckID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CreatorUserID", deck.CreatorUserId);
            cmd.Parameters.AddWithValue("@DeckName", deck.DeckName);
            cmd.Parameters.AddWithValue("@Created", deck.Created);
            cmd.Parameters.AddWithValue("@Description", deck.Description);
            cmd.Parameters.AddWithValue("@DeckColor", deck.DeckColor);

            cmd.ExecuteNonQuery();

            conn.Close();

            Deck d = new Deck();

            return d;
        }

        internal void DeleteDeck(int deckId)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "DELETE [dbo].[Deck] WHERE [DeckID] = @DeckID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DeckID", deckId);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
