using System.Data;
using System.Data.SqlClient;

namespace Backend.Infrastructura.ProcedimientosAlmacenados.Command
{
    public class CommandSender
    {
        private SqlCommand sqlCommand { set; get; }
        private CommandSender()
        {

        }

        public int Excecute()
        {
           return sqlCommand.ExecuteNonQuery();
        }

        public SqlCommand GetCommand() => sqlCommand;
        public class Builder
        {
            private readonly CommandSender _command;
            public Builder()
            {
                _command = new CommandSender();
                _command.sqlCommand = new SqlCommand();
                _command.sqlCommand.CommandType = CommandType.StoredProcedure;
            }

            public Builder SetProcedureName(string parameter)
            {
                _command.sqlCommand.CommandText = parameter;
                _command.sqlCommand.Connection = SQLConfiguration.GetConnection();
                return this;
            }

            public Builder WithParameter<T>(string param, T value)
            {
                _command.sqlCommand.Parameters.AddWithValue($"@{param}", value);
                
                return this;
            }

            public CommandSender Build()
            {
                return _command;
            }
        }
    }
}
