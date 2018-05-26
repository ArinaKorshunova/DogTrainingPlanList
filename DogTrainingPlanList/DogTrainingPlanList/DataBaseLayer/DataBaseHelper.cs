using DogTrainingPlanList.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace DogTrainingPlanList.DataBaseLayer
{
    public static class DataBaseHelper
    {
        public static void InitialCreate()
        {
            bool existDataBase = File.Exists(Constatns.DataBaseName);
            if (!existDataBase)
            {
                SQLiteConnection.CreateFile(Constatns.DataBaseName);
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={Constatns.DataBaseName};Version=3;");
            m_dbConnection.Open();

            string sql = $"create table if not exists {Constatns.SkillTableName} (Id integer primary key autoincrement, Name text, Effort integer, PercentOfCompletion integer, IsHide integer, Type text);";
            sql += $"create table if not exists {Constatns.TrainingTableName} (Id integer primary key autoincrement, TrainingDate text, Duration integer, [Order] integer);";
            sql += $"create table if not exists {Constatns.TrainingSkillsTableName} (Id integer primary key autoincrement, TrainingId integer, SkillId integer, [Order] integer, Duration integer, IsComplete integer, Value integer);";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            if (!existDataBase)
            {
                try
                {
                    SQLiteCommand fillSkills = new SQLiteCommand(FillSkillsTableScript(), m_dbConnection);
                    fillSkills.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                }

            }

            m_dbConnection.Close();
        }

        private static string FillSkillsTableScript()
        {
            string sql =  $"insert into  {Constatns.SkillTableName} (Name, Effort, PercentOfCompletion, IsHide, Type) values ";

            //навыки
            sql += $"('Наведение', 0, 0, 0, '{Constatns.SkillTypeSkill}'),";
            sql += $"('Выдержка', 2, 0, 0, '{Constatns.SkillTypeSkill}'),";
            sql += $"('Смена состояний', 2, 0, 0, '{Constatns.SkillTypeSkill}'),";

            //времяпровждение
            sql += $"('Угадайка', 2, 0, 0, '{Constatns.SkillTypePastime}'),";
            sql += $"('Интерактивные игрушки', 0, 0, 0, '{Constatns.SkillTypePastime}'),";

            //трюки
            sql += $"('Змейка', 1, 0, 0, '{Constatns.SkillTypeTrick}'),";
            sql += $"('Назад', 2, 0, 0, '{Constatns.SkillTypeTrick}'),";
            sql += $"('Кружись', 1, 0, 0, '{Constatns.SkillTypeTrick}'),";
            sql += $"('Прыжки', 2, 0, 0, '{Constatns.SkillTypeTrick}'),";
            sql += $"('Лапки', 1, 0, 0, '{Constatns.SkillTypeTrick}'),";
            sql += $"('Дай лапу', 0, 0, 0, '{Constatns.SkillTypeTrick}'),";
            sql += $"('Прячься', 2, 0, 0, '{Constatns.SkillTypeTrick}'),";

            //команды
            sql += $"('Глазки', 2, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Ко мне', 2, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Сюда', 1, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Со мной', 1, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Рядом', 2, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Не тяни', 1, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Место', 2, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Аппорт', 2, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Сидеть', 1, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Стоять', 1, 0, 0, '{Constatns.SkillTypeCommand}'),";
            sql += $"('Лежать', 1, 0, 0, '{Constatns.SkillTypeCommand}'),";

            //комплекс
            sql += $"('Сидеть-стоять', 2, 0, 0, '{Constatns.SkillTypeComplex}'),";
            sql += $"('Сидеть-лежать', 2, 0, 0, '{Constatns.SkillTypeComplex}'),";
            sql += $"('Лежать-стоять', 2, 0, 0, '{Constatns.SkillTypeComplex}')";

            return sql;

        }

        public static List<Skill> GetNotHighSkills()
        {
            List<Skill> skills = new List<Skill>();

            using (SQLiteConnection con = new SQLiteConnection($"Data Source={Constatns.DataBaseName};Version=3;"))
            {
                con.Open();

                string stm = $"SELECT * FROM {Constatns.SkillTableName} where IsHide = 0";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            skills.Add(new Skill {
                                Id = rdr.GetInt32(0),
                                Name = rdr.GetString(1),
                                Effort = rdr.GetInt32(2),
                                PercentOfCompletion = rdr.GetInt32(3),
                                IsHide = rdr.GetInt32(4) > 0,
                                Type = rdr.GetString(5)

                            });
                        }
                    }
                }

                con.Close();
            }

            return skills;
        }
        public static List<Skill> GetAllSkills()
        {
            List<Skill> skills = new List<Skill>();

            using (SQLiteConnection con = new SQLiteConnection($"Data Source={Constatns.DataBaseName};Version=3;"))
            {
                con.Open();

                string stm = $"SELECT * FROM {Constatns.SkillTableName}";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            skills.Add(new Skill
                            {
                                Id = rdr.GetInt32(0),
                                Name = rdr.GetString(1),
                                Effort = rdr.GetInt32(2),
                                PercentOfCompletion = rdr.GetInt32(3),
                                IsHide = rdr.GetInt32(4) > 0,
                                Type = rdr.GetString(5)

                            });
                        }
                    }
                }

                con.Close();
            }

            return skills;
        }

        public static Skill GetSkillById(int id)
        {

            Skill skill = new Skill();

            using (SQLiteConnection con = new SQLiteConnection($"Data Source={Constatns.DataBaseName};Version=3;"))
            {
                con.Open();

                string stm = $"SELECT * FROM {Constatns.SkillTableName} where Id = {id}";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            skill = new Skill
                            {
                                Id = rdr.GetInt32(0),
                                Name = rdr.GetString(1),
                                Effort = rdr.GetInt32(2),
                                PercentOfCompletion = rdr.GetInt32(3),
                                IsHide = rdr.GetInt32(4) > 0,
                                Type = rdr.GetString(5)

                            };
                        }
                    }
                }

                con.Close();
            }

            return skill;
        }

        public static void EditSkill(Skill skill)
        {
            using (SQLiteConnection con = new SQLiteConnection($"Data Source={Constatns.DataBaseName};Version=3;"))
            {
                con.Open();

                string stm = $"UPDATE {Constatns.SkillTableName} set Name = '{skill.Name}', Effort = {skill.Effort}, PercentOfCompletion = {skill.PercentOfCompletion}, IsHide = {(skill.IsHide ? 1 : 0)}, Type = '{skill.Type}' where Id = {skill.Id}";

                SQLiteCommand cmd = new SQLiteCommand(stm, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
        public static void AddSkill(Skill skill)
        {
            using (SQLiteConnection con = new SQLiteConnection($"Data Source={Constatns.DataBaseName};Version=3;"))
            {
                con.Open();

                string sql = $"insert into  {Constatns.SkillTableName} (Name, Effort, PercentOfCompletion, IsHide, Type) values ('{skill.Name}', {skill.Effort}, {skill.PercentOfCompletion}, {(skill.IsHide ? 1 : 0)}, '{skill.Type}')";
                
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
        public static void HideSkill(int id)
        {
            using (SQLiteConnection con = new SQLiteConnection($"Data Source={Constatns.DataBaseName};Version=3;"))
            {
                con.Open();

                string stm = $"UPDATE {Constatns.SkillTableName} set IsHide = 1 where Id = {id}";

                SQLiteCommand cmd = new SQLiteCommand(stm, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
