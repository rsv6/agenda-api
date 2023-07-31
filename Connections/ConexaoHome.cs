namespace agenda_api.Connections;

public class ConexaoHome
{
    public string ConnexaoString { get; set; }
    public ConexaoHome()
    {
        this.ConnexaoString = "Data Source=localhost; User Id=sa; Password=screeD81915262; Initial Catalog=homedb; Trust Server Certificate=true";
    }
}