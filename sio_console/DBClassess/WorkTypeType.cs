namespace sio_console
{
    public class WorkTypeType :DataBaseStorageHelper, IDataBaseStorage, INameCodeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Present { get; set; }

    
        public static WorkTypeType Load(string code)
        {
            return MysqlCore.DB_Main().GetSingleObject<WorkTypeType>("select * from workss where code='" + code + "';");
        }
    }
}