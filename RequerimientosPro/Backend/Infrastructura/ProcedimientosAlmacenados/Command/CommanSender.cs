using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructura.ProcedimientosAlmacenados.Command
{
    public class CommandSender 
    {
        private SqlCommand sqlCommand;
        private CommandSender()
        {
            
        }

        public SqlCommand GetResult() => sqlCommand;
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

            public CommandSender Build()  {
                return _command;
            }
        }
    }
}
