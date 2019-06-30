using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;

namespace AccountingPerformanceModel
{
    /// <summary>
    /// Класс для работы с базой данных OleDB сервера
    /// </summary>
    public class OleDbServer
    {
        public string Connection { get; set; } = string.Empty; // строка подключения
        public string LastError { get; set; } = string.Empty; // последняя ошибка

        /// <summary>
        /// Выполнить SQL-запрос
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public bool ExecSql(string sql, Dictionary<string, object> columns = null)
        {
            bool result = false;
            using (var con = new OleDbConnection(Connection))
            {
                con.Open();
                using (OleDbCommand command = new OleDbCommand(sql, con))
                {
                    try
                    {
                        if (columns != null)
                        {
                            foreach (var key in columns.Keys)
                                command.Parameters.AddWithValue($"@{key}", columns[key]);
                        }
                        var rows = command.ExecuteNonQuery();
                        LastError = "";
                        result = true;
                    }
                    catch (Exception e)
                    {
                        LastError = e.Message;
                        return false;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Проверка на существование записи с ключом
        /// </summary>
        /// <param name="table"></param>
        /// <param name="keyName"></param>
        /// <param name="valueValue"></param>
        /// <returns></returns>
        public bool KeyRecordExists(string table, string keyName, Guid valueValue)
        {
            bool result = false;
            using (var con = new OleDbConnection(Connection))
            {
                con.Open();
                var sql = $"SELECT COUNT(*) FROM `{table}` WHERE `{keyName}` = @{keyName}";
                using (OleDbCommand command = new OleDbCommand(sql, con))
                {
                    command.Parameters.AddWithValue($"@{keyName}", "P"+valueValue.ToString());
                    try
                    {
                        var value = (int)command.ExecuteScalar();
                        LastError = "";
                        result = value > 0;
                    }
                    catch (Exception e)
                    {
                        LastError = e.Message;
                        return false;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Запрос на вставку данных
        /// </summary>
        /// <param name="table">Имя таблицы</param>
        /// <param name="row">Набор данных для вставки</param>
        /// <returns></returns>
        public bool InsertInto(string table, Dictionary<string, object> columns)
        {
            // формирование запроса для изменения
            var props = new List<string>();
            var values = new List<string>();
            foreach (var key in columns.Keys)
            {
                props.Add($"`{key}`");
                var value = columns[key];
                values.Add($"@{key}");
            }
            var sql = $"INSERT INTO `{table}` ({string.Join(",", props)}) VALUES ({string.Join(",", values)})";
            return ExecSql(sql, columns);
        }

        /// <summary>
        /// Запрос на изменение данных
        /// </summary>
        /// <param name="table">Имя таблицы</param>
        /// <param name="columns">Набор данных для изменения</param>
        /// <returns></returns>
        public bool UpdateInto(string table, Dictionary<string, object> columns)
        {
            // формирование запроса для изменения
            // -- var values = new List<string>();
            // -- var indexName = columns.Keys.First();
            // -- foreach (var key in columns.Keys.Skip(1)) values.Add($"`{key}`=@{key}");
            // -- var sql = $"UPDATE `{table}` SET {string.Join(", ", values)} WHERE [{indexName}]=@{indexName}";
            // -- return ExecSql(sql, columns);
            return DeleteInto(table, columns) ? InsertInto(table, columns) : false;
        }

        /// <summary>
        /// Удаление всех записей из таблицы
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool DeleteInto(string table)
        {
            // формирование запроса для удаления
            return ExecSql($"DELETE FROM `{table}`");
        }

        /// <summary>
        /// Удаление конкретной записи
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public bool DeleteInto(string table, Dictionary<string, object> columns)
        {
            // формирование запроса для удаления
            var indexName = columns.Keys.First();
            return ExecSql($"DELETE FROM `{table}` WHERE `{indexName}`=@{indexName}", columns);
        }

        /// <summary>
        /// Получение набора данных из таблицы
        /// </summary>
        /// <param name="table">Имя таблицы</param>
        /// <param name="likefield">Имя поля для фильтра</param>
        /// <param name="text2find">Значение для фильтра</param>
        /// <returns></returns>
        public DataSet GetRows(string table)
        {
            using (var con = new OleDbConnection(Connection))
            {
                using (var da = new OleDbDataAdapter($"SELECT * FROM `{table}`", con))
                {
                    var ds = new DataSet();
                    try
                    {
                        da.Fill(ds, table);
                        LastError = "";
                    }
                    catch (Exception ex)
                    {
                        LastError = ex.Message;
                    }
                    return ds;
                }
            }
        }

    }
}
