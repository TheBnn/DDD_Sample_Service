using Newtonsoft.Json;

namespace Wbx.Sample.Persistence.DatabaseContext;

[JsonObject(MemberSerialization.OptIn)]
public class DatabaseSettings
{
    public string ConnectionString { set; get; }
}
