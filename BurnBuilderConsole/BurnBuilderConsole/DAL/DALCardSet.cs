using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurnBuilderConsole.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BurnBuilderConsole.DAL
{
    public class DALCardSet
    {
        private readonly IConfiguration configuration;

        public DALCardSet(IConfiguration config)
        {
            this.configuration = config;
        }

        public int InsertCardSet(CardSet cardSet)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "INSERT INTO [dbo].[CardSet]([Code],[Name],[Type],[Booster],[ReleaseDate],[Block],[OnlineOnly])" + " VALUES (@Code,@Name,@Type,@Booster,@ReleaseDate,@Block,@OnlineOnly) select SCOPE_IDENTITY() as id";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Code", cardSet.Code);
            cmd.Parameters.AddWithValue("@Name", cardSet.Name);
            cmd.Parameters.AddWithValue("@Type", cardSet.Type);
            cmd.Parameters.AddWithValue("@Booster", cardSet.Booster);
            cmd.Parameters.AddWithValue("@ReleaseDate", cardSet.ReleaseDate);
            cmd.Parameters.AddWithValue("@Block", cardSet.Block);
            cmd.Parameters.AddWithValue("@OnlineOnly", cardSet.OnlineOnly);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int cardSetId = Convert.ToInt32(reader[0].ToString());

            reader.Close();

            conn.Close();

            return cardSetId;
        }

        public CardSet GetCardSetById(int cardSetId)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query =
                "SELECT [Code], [Name], [Type], [Booster], [ReleaseDate], [Block], [OnlineOnly] FROM [dbo].[CardSet] WHERE CardSetID = @CardSetID";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@CardSetID", cardSetId);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string code = reader["Code"].ToString();
            string name = reader["Name"].ToString();
            string type = reader["Type"].ToString();
            string booster = reader["Booster"].ToString();
            DateTime releaseDate = Convert.ToDateTime(reader["ReleaseDate"].ToString());
            string block = reader["Block"].ToString();
            bool onlineOnly = Convert.ToBoolean(reader["OnlineOnly"].ToString());

            reader.Close();

            conn.Close();

            CardSet cSet = new CardSet();
            cSet.Code = code;
            cSet.Name = name;
            cSet.Type = type;
            cSet.Booster = booster;
            cSet.ReleaseDate = releaseDate;
            cSet.Block = block;
            cSet.OnlineOnly = onlineOnly;

            return cSet;
        }

        public CardSet UpdateCardSet(CardSet cardSet)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query =
                "UPDATE [dbo].[CardSet] SET [Code] = @Code, [Name] = @Name, [Type] = @Type, [Booster] = @Booster, [ReleaseDate] = @ReleaseDate, [Block] = @Block, [OnlineOnly] = @OnlineOnly WHERE CardSetID = @CardSetID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Code", cardSet.Code);
            cmd.Parameters.AddWithValue("@Name", cardSet.Name);
            cmd.Parameters.AddWithValue("@Type", cardSet.Type);
            cmd.Parameters.AddWithValue("@Booster", cardSet.Booster);
            cmd.Parameters.AddWithValue("@ReleaseDate", cardSet.ReleaseDate);
            cmd.Parameters.AddWithValue("@Block", cardSet.Block);
            cmd.Parameters.AddWithValue("@OnlineOnly", cardSet.OnlineOnly);

            cmd.ExecuteNonQuery();

            conn.Close();

            CardSet cSet = new CardSet();

            return cSet;
        }

        public void DeleteCardSet(int cardSetId)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "DELETE [dbo].[CardSet] WHERE [CardSetID] = @CardSetID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CardSetID", cardSetId);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
