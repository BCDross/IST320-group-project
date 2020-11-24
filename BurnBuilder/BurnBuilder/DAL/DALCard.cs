using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurnBuilder.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BurnBuilder.DAL
{
    public class DALCard
    {
        private readonly IConfiguration configuration;

        public DALCard(IConfiguration config)
        {
            this.configuration = config;
        }

        internal int InsertCard(Card card)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query =
                "INSERT INTO [dbo].[Card]([Name],[ManaCost],[Cmc],[Colors],[ColorIdentity],[Type],[Supertypes],[Types],[Subtypes],[Rarity],[Set],[SetName],[Text],[Artist],[Number],[Layout],[MultiverseID],[ImageUrl],[Rulings],[ForeignNames],[Printings],[OriginalText],[Legalities],[Id])" +
                " VALUES(@Name,@ManaCost,@Cmc,@Colors,@ColorIdentity,@Type,@Supertypes,@Types,@Subtypes,@Rarity,@Set,@SetName,@Text,@Artist,@Number,@Layout,@MultiverseID,@ImageUrl,@Rulings,@ForeignNames,@Printings,@OriginalText,@OriginalType,@Legalities,@Id) select SCOPE_IDENTITY() as id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", card.Name);
            cmd.Parameters.AddWithValue("@ManaCost", card.ManaCost);
            cmd.Parameters.AddWithValue("@Cmc", card.Cmc);
            cmd.Parameters.AddWithValue("@Colors", card.Colors);
            cmd.Parameters.AddWithValue("@ColorIdentity", card.ColorIdentity);
            cmd.Parameters.AddWithValue("@Type", card.Type);
            cmd.Parameters.AddWithValue("@Supertypes", card.Supertypes);
            cmd.Parameters.AddWithValue("@Types", card.Types);
            cmd.Parameters.AddWithValue("@Subtypes", card.Subtypes);
            cmd.Parameters.AddWithValue("@Rarity", card.Rarity);
            cmd.Parameters.AddWithValue("@Set", card.Set);
            cmd.Parameters.AddWithValue("@SetName", card.SetName);
            cmd.Parameters.AddWithValue("@Text", card.Text);
            cmd.Parameters.AddWithValue("@Artist", card.Artist);
            cmd.Parameters.AddWithValue("@Number", card.Number);
            cmd.Parameters.AddWithValue("@Layout", card.Layout);
            cmd.Parameters.AddWithValue("@MultiverseID", card.MultiverseID);
            cmd.Parameters.AddWithValue("@ImageUrl", card.ImageUrl);
            cmd.Parameters.AddWithValue("@Rulings", card.Rulings);
            cmd.Parameters.AddWithValue("@ForeignNames", card.ForeignNames);
            cmd.Parameters.AddWithValue("@Printings", card.Printings);
            cmd.Parameters.AddWithValue("@OriginalText", card.OriginalText);
            cmd.Parameters.AddWithValue("@OriginalType", card.OriginalType);
            cmd.Parameters.AddWithValue("@Legalities", card.Legalities);
            cmd.Parameters.AddWithValue("@ID", card.Id);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int cardId = Convert.ToInt32(reader[0].ToString());

            reader.Close();

            conn.Close();
            
            return cardId;
        }

        internal Card GetCardById(int cardId)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query =
                "SELECT [Name],[ManaCost],[Cmc],[Colors],[ColorIdentity],[Type],[Supertypes],[Types],[Subtypes],[Rarity],[Set],[SetName],[Text],[Artist],[Number],[Layout],[MultiverseID],[ImageUrl],[Rulings],[ForeignNames],[Printings],[OriginalText],[Legalities],[Id] FROM [dbo].[Card] WHERE CardID = @CardID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CardID", cardId);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string name = reader["Name"].ToString();
            string manaCost = reader["ManaCost"].ToString();
            decimal cmc = Convert.ToDecimal(reader["Cmc"].ToString());
            string colors = reader["Colors"].ToString();
            string colorIdentity = reader["ColorIdentity"].ToString();
            string type = reader["Type"].ToString();
            string supertypes = reader["Supertypes"].ToString();
            string types = reader["Types"].ToString();
            string subtypes = reader["Subtypes"].ToString();
            string rarity = reader["Rarity"].ToString();
            string set = reader["Set"].ToString();
            string setName = reader["SetName"].ToString();
            string text = reader["Text"].ToString();
            string artist = reader["Artist"].ToString();
            string number = reader["Number"].ToString();
            string layout = reader["Layout"].ToString();
            int multiverseID = Convert.ToInt32(reader["MultiverseID"].ToString());
            string imageUrl = reader["ImageUrl"].ToString();
            string rulings = reader["Rulings"].ToString();
            string foreignNames = reader["ForeignNames"].ToString();
            string printings = reader["Printings"].ToString();
            string originalText = reader["OriginalText"].ToString();
            string originalType = reader["OriginalType"].ToString();
            string legalities = reader["Legalities"].ToString();
            string id = reader["ID"].ToString();

            reader.Close();

            conn.Close();

            Card c = new Card();
            c.Name = name;
            c.ManaCost = manaCost;
            c.Cmc = cmc;
            c.Colors = colors;
            c.ColorIdentity = colorIdentity;
            c.Type = type;
            c.Supertypes = supertypes;
            c.Types = types;
            c.Subtypes = subtypes;
            c.Rarity = rarity;
            c.Set = set;
            c.SetName = setName;
            c.Text = text;
            c.Artist = artist;
            c.Number = number;
            c.Layout = layout;
            c.MultiverseID = multiverseID;
            c.ImageUrl = imageUrl;
            c.Rulings = rulings;
            c.ForeignNames = foreignNames;
            c.Printings = printings;
            c.OriginalText = originalText;
            c.OriginalType = originalType;
            c.Legalities = legalities;
            c.Id = id;

            return c;
        }

        internal Card UpdateCard(Card card)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query =
                "UPDATE [dbo].[Card] SET [Name] = @Name, [ManaCost] = @ManaCost, [CmC] = @Cmc, [Colors] = @Colors, [ColorIdentity] = @ColorIdentity, [Type] = @Type, [Supertypes] = @Supertypes, [Types] = @Types, [Subtypes] = @Subtypes, [Rarity] = @Rarity, [Set] = @Set, [SetName] = @SetName, [Text] = @Text, [Artist] = @Artist, [Number] = @Number, [Layout] = @Layout, [MultiverseID] = @MultiverseID, [ImageUrl] = @ImageUrl, [Rulings] = @Rulings, [ForeignNames] = @ForeignNames, [Printings] = @Printings, [OriginalText] = @OriginalText, [OriginalType] = @OriginalType, [Legalities] = @Legalities, [ID] = @Id WHERE [CardID] = @CardID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", card.Name);
            cmd.Parameters.AddWithValue("@ManaCost", card.ManaCost);
            cmd.Parameters.AddWithValue("@Cmc", card.Cmc);
            cmd.Parameters.AddWithValue("@Colors", card.Colors);
            cmd.Parameters.AddWithValue("@ColorIdentity", card.ColorIdentity);
            cmd.Parameters.AddWithValue("@Type", card.Type);
            cmd.Parameters.AddWithValue("@Supertypes", card.Supertypes);
            cmd.Parameters.AddWithValue("@Types", card.Types);
            cmd.Parameters.AddWithValue("@Subtypes", card.Subtypes);
            cmd.Parameters.AddWithValue("@Rarity", card.Rarity);
            cmd.Parameters.AddWithValue("@Set", card.Set);
            cmd.Parameters.AddWithValue("@SetName", card.SetName);
            cmd.Parameters.AddWithValue("@Text", card.Text);
            cmd.Parameters.AddWithValue("@Artist", card.Artist);
            cmd.Parameters.AddWithValue("@Number", card.Number);
            cmd.Parameters.AddWithValue("@Layout", card.Layout);
            cmd.Parameters.AddWithValue("@MultiverseID", card.MultiverseID);
            cmd.Parameters.AddWithValue("@ImageUrl", card.ImageUrl);
            cmd.Parameters.AddWithValue("@Rulings", card.Rulings);
            cmd.Parameters.AddWithValue("@ForeignNames", card.ForeignNames);
            cmd.Parameters.AddWithValue("@Printings", card.Printings);
            cmd.Parameters.AddWithValue("@OriginalText", card.OriginalText);
            cmd.Parameters.AddWithValue("@OriginalType", card.OriginalType);
            cmd.Parameters.AddWithValue("@Legalities", card.Legalities);
            cmd.Parameters.AddWithValue("@ID", card.Id);

            cmd.ExecuteNonQuery();

            conn.Close();

            Card c = new Card();

            return c;
        }

        internal void DeleteCard(int cId)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "DELETE [dbo].[Card] WHERE CardID = @CardID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CardID", cId);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
