//using System.Data;
//using System.Data.Common;
//using System.Data.SqlClient;



//namespace API_Web.Classes;

//public class SQLManga
//{
//    /// <summary>
//    /// Renvoye un utilisateur de la BDD avec son id, Nom et Prenom
//    /// </summary>
//    /// <param name="sqlConnection"></param>
//    /// <param name="id_planon"></param>
//    /// <returns></returns>
//    public Utilisateur selectUtilisateur(SqlConnection sqlConnection, string id_planon)
//    {

//        string queryString;
//        Utilisateur utilisateur = new();

//        queryString = $@"
//            SELECT 
//                id,
//                Nom,
//                Prenom
//            FROM 
//                Utilisateur
//            Where 
//                id_planon= '{id_planon}';";

//        // Créez un objet Command.
//        SqlCommand cmd = new();

//        // Combinez l'objet Command avec Connection.
//        cmd.Connection = sqlConnection;

//        //affecte la requete sql a la propriete commandeText
//        cmd.CommandText = queryString;




//        using (DbDataReader reader = cmd.ExecuteReader())
//        {
//            if (reader.HasRows)
//            {

//                while (reader.Read())
//                {
//                    // Récupérez l'index de Column Emp_ID dans l'instruction de requête SQL.

//                    utilisateur.Nom = reader.GetString("Nom");
//                    utilisateur.Prenom = reader.GetString("Prenom");
//                    utilisateur.WriteId(reader.GetInt32("id"));

//                }
//            }


//        }

//        cmd.Dispose();
//        return utilisateur;

//    }

//}