namespace agenda_api.Connections;

public class ConexaoHome
{
    public string ConnexaoString { get; set; }
    public ConexaoHome()
    {
        // this.ConnexaoString = "Data Source=localhost; User Id=sa; Password=screeD81915262; Initial Catalog=homedb; Trust Server Certificate=true";
        this.ConnexaoString = "Data Source=10.1.5.225; User Id=sa; Password=underline; Initial Catalog=dbAgenda; Trust Server Certificate=true";
    }
}