using DesafioBase2.Helpers;
using DesafioBase2.Queries;

namespace DesafioBase2.DataBaseSteps
{
    public class UsuariosDBSteps
    {
        public static string RetornaSenhaDoUsuario(string username)
        {
            //select user.senha from usuarios user where user.username = $username;
            string query = UsuariosQueries.RetornaSenhaUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
    }
}
