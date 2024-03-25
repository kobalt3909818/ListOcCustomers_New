using ListOfCustomers_New.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ListOfCustomers_New.Models
{
    class FileService<T>
                where T : class


    {
        public static ObservableCollection<T> ListOfValues { get; set; }
        public static string Puth;

        public FileService(T Value = default, string CustomerID = "", string AccountID = "")
        {
            if (typeof(T) == typeof(Customers))
            {
                Puth = "ListOfCustomers.xml";
                ListOfValues = ReadCustomers() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(Departments))
            {
                Puth = "ListOfDepartments.xml";
                ListOfValues = ReadDepartments() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(IAccounts<Accounts_1>))
            {
                Puth = "ListOfAccounts.xml";
                if (CustomerID == "")
                {
                    ListOfValues = ReadAccounts() as ObservableCollection<T>;
                }
                else
                {
                    ListOfValues = GetListAccountsByID(CustomerID) as ObservableCollection<T>;
                }
            }
            else if (typeof(T) == typeof(TransferAccounts))
            {
                Puth = "ListOfTransfers.xml";
                if (AccountID != "" & CustomerID != "")
                {
                    ListOfValues = GetListOfTransfersByID(CustomerID, AccountID) as ObservableCollection<T>; ;

                }
                else
                {
                    ListOfValues = ReadTransfers() as ObservableCollection<T>;
                }
            }
            else if (typeof(T) == typeof(AccountPercent))
            {
                Puth = "AccountPercents.xml";
                ListOfValues = ReadPercents() as ObservableCollection<T>;
            }
        }




        /// <summary>
        /// Получаем список без параметров
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<T> GetListOfValues()
        {
            FileService<T> usCmr = new FileService<T>();
            return ListOfValues;
        }

        /// <summary>
        /// Получаем список из файла по одному параметру
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public static ObservableCollection<T> GetListOfValues(string CustomerID)
        {
            FileService<T> usCmr = new FileService<T>(default, CustomerID);
            return ListOfValues;
        }
        /// <summary>
        /// Получаем список по двум переданным параметрам
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public static ObservableCollection<T> GetListOfValues(string CustomerID, string AccountID)
        {
            FileService<T> usCmr = new FileService<T>(default, CustomerID, AccountID);
            return ListOfValues;
        }


        /// <summary>
        /// Вовзращает Список Значений массива по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ObservableCollection<IAccounts<Accounts_1>> GetListAccountsByID(string id)
        {
            var List = GetListOfValues() as ObservableCollection<IAccounts<Accounts_1>>;
            ObservableCollection<IAccounts<Accounts_1>> result = new ObservableCollection<IAccounts<Accounts_1>>();
            foreach (var item in List)
            {
                if (item.CustomerID == id)
                {
                    result.Add(item);
                }
            }
            return result;
        }



        /// <summary>
        /// Вовзращает Список Значений массива по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ObservableCollection<TransferAccounts> GetListOfTransfersByID(string CustomerID, string AccountID)
        {
            var List = GetListOfValues() as ObservableCollection<TransferAccounts>;
            ObservableCollection<TransferAccounts> result = new ObservableCollection<TransferAccounts>();
            foreach (var item in List)
            {
                if (item.CustomerID == CustomerID & item.AccountID == AccountID)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public static void AddDepartments(T str)
        {
            var str_ = str as Departments;
            var fndStr = Get_by_ID(str_.ID) as Departments;
            if (fndStr != null)
            {
                fndStr.Name = str_.Name;

            }
            else
            {
                ListOfValues.Add(str);
            }
        }

        /// <summary>
        /// Метод возвращает уникальный идентификатор таблицы Клиентов
        /// </summary>
        /// <returns></returns>
        public static string Return_ID()
        {

            int result = 1;
            //var lst_1 = new ObservableCollection<Customers>();
            var lst = new ObservableCollection<T>();
            if (typeof(T) == typeof(Customers))
            {
                lst = ReadCustomers() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(Departments))
            {
                lst = ReadDepartments() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(IAccounts<Accounts_1>))
            {
                lst = ReadAccounts() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(TransferAccounts))
            {
                lst = ReadTransfers() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(AccountPercent))
            {
                lst = ReadPercents() as ObservableCollection<T>;
            }



            if (typeof(T) == typeof(Departments))
            {
                if (lst.Count > 0)
                {
                    var lst_1 = lst as ObservableCollection<Departments>;
                    string nom = lst_1[lst_1.Count - 1].ID;
                    result = Convert.ToInt32(nom) + 1;
                }
            }
            else if (typeof(T) == typeof(Customers))
            {
                if (lst.Count > 0)
                {
                    var lst_1 = lst as ObservableCollection<Customers>;
                    string nom = lst_1[lst_1.Count - 1].ID;
                    result = Convert.ToInt32(nom) + 1;
                }
            }
            else if (typeof(T) == typeof(IAccounts<Accounts_1>))
            {
                if (lst.Count > 0)
                {
                    var lst_1 = lst as ObservableCollection<IAccounts<Accounts_1>>;
                    string nom = lst_1[lst_1.Count - 1].ID;
                    result = Convert.ToInt32(nom) + 1;
                }
            }
            else if (typeof(T) == typeof(TransferAccounts))
            {
                if (lst.Count > 0)
                {
                    var lst_1 = lst as ObservableCollection<TransferAccounts>;
                    string nom = lst_1[lst_1.Count - 1].ID;
                    result = Convert.ToInt32(nom) + 1;
                }
            }
            else if (typeof(T) == typeof(AccountPercent))
            {
                if (lst.Count > 0)
                {
                    var lst_1 = lst as ObservableCollection<AccountPercent>;
                    string nom = lst_1[lst_1.Count - 1].ID;
                    result = Convert.ToInt32(nom) + 1;
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Customers> ReadCustomers()
        {
            ObservableCollection<Customers> lst = new ObservableCollection<Customers>();

            if (File.Exists(Puth))
            {
                string xml = File.ReadAllText(Puth);
                var col = XDocument.Parse(xml).Descendants("Clients").Descendants("Client").ToList();
                foreach (var item in col)
                {
                    string ID = GetXMLElement("ID", "", item);
                    string First_Name = GetXMLElement("First_Name", "", item);
                    string Second_Name = GetXMLElement("Second_Name", "", item);
                    string Middle_Name = GetXMLElement("Middle_Name", "", item);
                    string Pasport = GetXMLElement("Pasport", "", item);
                    string Telephone = GetXMLElement("Telephone", "", item);
                    string Department = GetXMLElement("Department", "", item);

                    lst.Add(new Customers(ID, First_Name, Second_Name, Middle_Name, Telephone, Pasport, Department));
                }
            }
            return lst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public static void AddCustomers(ref T str)
        {
            var str_ = str as Customers;
            Customers fndStr = Get_by_ID(str_.ID) as Customers;
            if (fndStr != null)
            {
                fndStr.First_Name = str_.First_Name;
                fndStr.Second_Name = str_.Second_Name;
                fndStr.Middle_Name = str_.Middle_Name;
                fndStr.Pasport = str_.Pasport;
                fndStr.Telephone = str_.Telephone;
                fndStr.Department = str_.Department;
            }
            else
            {
                ListOfValues.Add(str);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="C"></typeparam>
        /// <param name="str"></param>
        static void SaveCustomers(ref T str)

        {
            var str_ = str as Customers;
            var f_str = Get_by_ID(str_.ID) as Customers;
            if (f_str != null)
            {
                f_str.First_Name = str_.First_Name;
                f_str.Second_Name = str_.Second_Name;
                f_str.Middle_Name = str_.Middle_Name;
                f_str.Pasport = str_.Pasport;
                f_str.Telephone = str_.Telephone;
                f_str.Department = str_.Department;

                CreateFileXML();
            }
            else
            {
                ListOfValues.Add(str);
                CreateFileXML();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="C"></typeparam>
        /// <param name="str"></param>
        static void SavePercents(ref T str)

        {
            var str_ = str as AccountPercent;
            var f_str = Get_by_ID(str_.ID) as AccountPercent;
            if (f_str != null)
            {
                f_str.Date = str_.Date;
                f_str.Number = str_.Number;
                f_str.IDAccount = str_.IDAccount;
                f_str.Ammount = str_.Ammount;
 
                CreateFileXML();
            }
            else
            {
                ListOfValues.Add(str);
                CreateFileXML();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="C"></typeparam>
        /// <param name="str"></param>
        static void SaveAccounts(ref T str)

        {
            var str_ = str as IAccounts<Accounts_1>;
            var f_str = Get_by_ID(str_.ID) as IAccounts<Accounts_1>;
            if (f_str != null)
            {
                f_str.Number = str_.Number;
                f_str.Rate = str_.Rate;
                f_str.TypeOfAccount = str_.TypeOfAccount;
                f_str.Ammount = str_.Ammount;
                f_str.CustomerID = str_.CustomerID;
                f_str.DateOpen = str_.DateOpen;
                f_str.DateClose = str_.DateClose;

                CreateFileXML();
            }
            else
            {
                ListOfValues.Add(str);
                CreateFileXML();
            }
        }



        /// <summary>
        /// Сохраняет массив департаментов в файл
        /// </summary>
        /// <param name="str"></param>
        static void SaveDepartments(ref T str)
        {
            var str_ = str as Departments;
            var f_str = Get_by_ID(str_.ID) as Departments;
            if (f_str != null)
            {
                f_str.Name = str_.Name;
            }
            else
            {
                ListOfValues.Add(str);
            }

            CreateFileXML();
        }

        /// <summary>
        /// Метод сохраняет трансферы по Счетам 
        /// </summary>
        /// <param name="str"></param>
        private static void SaveTransferAccounts(ref T str)
        {
            {
                var str_ = str as TransferAccounts;
                if (ListOfValues == null)
                {
                    ListOfValues = GetListOfValues(str_.CustomerID, str_.AccountID);
                }

                var f_str = Get_by_ID(str_.ID) as TransferAccounts;
                if (f_str != null)
                {

                    f_str.Date = str_.Date;
                    f_str.CustomerID = str_.CustomerID;
                    f_str.AccountGetID = str_.AccountGetID;
                    f_str.Type = str_.Type;
                    f_str.Amount = str_.Amount;

                    CreateFileXML();
                }
                else
                {

                    ListOfValues.Add(str);
                    CreateFileXML();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static void SaveAll()
        {
            CreateFileXML();
        }


        /// <summary>
        /// Метод получает строку по уникальному идентификатору клиента
        /// </summary>
        /// <param name = "ID" ></ param >
        /// < returns ></ returns >
        public static void Save(T str)
        {
            if (typeof(T) == typeof(Customers))
            {
                SaveCustomers(ref str);
            }
            else if (typeof(T) == typeof(Departments))
            {
                SaveDepartments(ref str);
            }
            else if (typeof(T) == typeof(IAccounts<Accounts_1>))
            {
                SaveAccounts(ref str);
            }
            else if (typeof(T) == typeof(TransferAccounts))
            {
                SaveTransferAccounts(ref str);
            }
            else if (typeof(T) == typeof(AccountPercent))
            {
                SavePercents(ref str);
            }
            else
            {
                SaveAll();
            }
        }


        ///// <summary>
        ///// Метод удаляет строку из коллекции  
        ///// </summary>
        ///// <param name="item"></param>
        public static void RemoveRow(T item)
        {
            ListOfValues.Remove(item);
            SaveAll();
        }

        ///// <summary>
        ///// Метод получает строку из списка Клиентов  по ID 
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        public static T Get_by_ID(string ID)

        {
            var result = default(T);
            if (typeof(T) == typeof(Customers))
            {
                var ListOfValues_ = ListOfValues as ObservableCollection<Customers>;
                result = ListOfValues_.Where(x => x.ID.Equals(ID)).FirstOrDefault() as T;
            }
            else if (typeof(T) == typeof(Departments))
            {
                var ListOfValues_ = ListOfValues as ObservableCollection<Departments>;
                result = ListOfValues_.Where(x => x.ID.Equals(ID)).FirstOrDefault() as T;
                return result;
            }
            else if (typeof(T) == typeof(IAccounts<Accounts_1>))
            {
                var ListOfValues_ = ListOfValues as ObservableCollection<IAccounts<Accounts_1>>;
                result = ListOfValues_.Where(x => x.ID.Equals(ID)).FirstOrDefault() as T;
                return result;
            }
            else if (typeof(T) == typeof(TransferAccounts))
            {
                var ListOfValues_ = ListOfValues as ObservableCollection<TransferAccounts>;
                result = ListOfValues_.Where(x => x.ID.Equals(ID)).FirstOrDefault() as T;
                return result;
            
            }
            else if (typeof(T) == typeof(AccountPercent))
            {
                var ListOfValues_ = ListOfValues as ObservableCollection<AccountPercent>;
                result = ListOfValues_.Where(x => x.ID.Equals(ID)).FirstOrDefault() as T;
                return result;
            }

            return default(T);
        }

        /// <summary>
        /// Метод Создает XML файл и отражает Массив типа List в нем
        /// </summary>
        public static void CreateFileXML()
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
            if (typeof(T) == typeof(Customers))
            {

                XElement xClientBook = new XElement("Clients");

                var c_ListOfValues = ListOfValues as ObservableCollection<Customers>;
                foreach (var item in c_ListOfValues)
                {
                    XElement xClient = new XElement("Client", new XElement("ID", item.ID),
                                                              new XElement("First_Name", item.First_Name),
                                                              new XElement("Second_Name", item.Second_Name),
                                                              new XElement("Middle_Name", item.Middle_Name),
                                                              new XElement("Pasport", item.Pasport),
                                                              new XElement("Telephone", item.Telephone),
                                                              new XElement("Department", item.Department));
                    xClientBook.Add(xClient);
                }
                xClientBook.Save(Puth);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
            else if (typeof(T) == typeof(Departments))
            {
                XElement xClientBook = new XElement("Departments");
                var ListOfValues_ = ListOfValues as ObservableCollection<Departments>;
                foreach (var item in ListOfValues_)
                {
                    XElement xClient = new XElement("Department", new XElement("ID", item.ID),
                                                              new XElement("Name", item.Name));
                    xClientBook.Add(xClient);
                }
                xClientBook.Save(Puth);

            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
            else if (typeof(T) == typeof(IAccounts<Accounts_1>))
            {
                XElement xClientBook = new XElement("Accounts");
                var ListOfValues_ = ListOfValues as ObservableCollection<IAccounts<Accounts_1>>;
                foreach (var item in ListOfValues_)
                {
                    XElement xClient = new XElement("Account", new XElement("ID", item.ID),
                                                                  new XElement("Number", item.Number),
                                                                  new XElement("ID", item.Rate),
                                                                  new XElement("TypeOfAccount", item.TypeOfAccount),
                                                                  new XElement("Rate", item.Rate),
                                                                  new XElement("Ammount", item.Ammount),
                                                                  new XElement("CustomerID", item.CustomerID),
                                                                  new XElement("DateOpen", item.DateOpen),
                                                                  new XElement("DateClose", item.DateClose));
                    xClientBook.Add(xClient);
                }
                xClientBook.Save(Puth);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
            else if (typeof(T) == typeof(AccountPercent))
            {
                XElement xClientBook = new XElement("AccountPercents");
                var ListOfValues_ = ListOfValues as ObservableCollection<AccountPercent>;
                foreach (var item in ListOfValues_)
                {
                    XElement xClient = new XElement("Account", new XElement("ID", item.ID),
                                                                  new XElement("Date", item.Date),
                                                                  new XElement("Number", item.Number),
                                                                  new XElement("IDAccount", item.IDAccount),
                                                                  new XElement("Ammount", item.Ammount));
                                                                 
                    xClientBook.Add(xClient);
                }
                xClientBook.Save(Puth);
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
            else if (typeof(T) == typeof(TransferAccounts))
            {
                XElement xClientBook = new XElement("Transfers");
                var ListOfValues_ = ListOfValues as ObservableCollection<TransferAccounts>;
                var ListTurnoverAccount = new ObservableCollection<AccountTurnover>();
                foreach (var item in ListOfValues_)
                {
                    XElement xClient = new XElement("Account", new XElement("ID", item.ID),
                                                                  new XElement("Date", item.Date),
                                                                  new XElement("CustomerID", item.CustomerID),
                                                                  new XElement("AccountID", item.AccountID),
                                                                  new XElement("Number", item.Number),
                                                                  new XElement("AccountGetID", item.AccountGetID),
                                                                  new XElement("NumberGet", item.NumberGet),
                                                                  new XElement("Type", item.Type),
                                                                  new XElement("Amount", item.Amount));

                    //Добавим приход и расход по счетам 
                    ListTurnoverAccount = ReadTurnOvers();
                    if (item.Type != "1") //Если это перевод тогда не делаем движение по расходу 
                    {
                        //Expense
                        ListTurnoverAccount.Add(new AccountTurnover(item.AccountID, "2", item.Amount));
                    }
                    //Income   
                    ListTurnoverAccount.Add(new AccountTurnover(item.AccountGetID, "1", item.Amount));

                    xClientBook.Add(xClient);

                }
                xClientBook.Save(Puth);

                //////////////////////////////////////////////////////////////////////////////////////////////////
                //Сохраним движжения по счету
                SaveTurnOvers(ListTurnoverAccount);

            }
        }

        /// <summary>
        /// Сохраним движения по счету
        /// </summary>
        /// <param name="ListTurnoverAccount"></param>
        private static void SaveTurnOvers(ObservableCollection<AccountTurnover> listTurnoverAccount)
        {
            XElement xClientBook = new XElement("TurnOvers");
            xClientBook = new XElement("AccountTurnover");
            foreach (var item in listTurnoverAccount)
            {
                XElement xClient = new XElement("Account", new XElement("AccountID", item.AccountID),
                                                              new XElement("TypeOfTurnover", item.TypeOfTurnover),
                                                              new XElement("Amount", item.Amount));

                xClientBook.Add(xClient);
            }
            xClientBook.Save("ListOfTurnOvers.xml");
        }

        ///// <summary>
        ///// Метод получает строку по уникальному идентификатору клиента
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        public static void UpdateByID(T str)

        {
            if (typeof(T) == typeof(Customers))
            {
                var paramTable = GetListFromFile() as ObservableCollection<Customers>;
                var str_c = str as Customers;
                var f_str = paramTable.Where(x => x.ID.Equals(str_c.ID)).FirstOrDefault();
                if (f_str != null)
                {
                    f_str.ID = str_c.ID;
                    f_str.First_Name = str_c.First_Name;
                    f_str.Second_Name = str_c.Second_Name;
                    f_str.Middle_Name = str_c.Middle_Name;
                    f_str.Pasport = str_c.Pasport;
                    f_str.Telephone = str_c.Telephone;
                    f_str.Department = str_c.Department;
                }

                CreateFileXML();
            }
        }




        ///// <summary>
        ///// Возвращает значение переданного атрибута XML
        ///// </summary>
        ///// <param name="p1"></param>
        ///// <param name="p2"></param>
        private static string GetXMLElement(string p1, string p2, XElement item)
        {
            return item.Element(p1).Value;
        }

        /// <summary>
        /// Получить все записи из XML для пользовтаеля Consultant
        /// </summary>
        /// <param name="puth"></param>
        public static ObservableCollection<Departments> ReadDepartments()
        {
            ObservableCollection<Departments> lst = new ObservableCollection<Departments>();
            if (File.Exists(Puth))
            {
                string xml = File.ReadAllText(Puth);
                var col = XDocument.Parse(xml).Descendants("Departments").Descendants("Department").ToList();
                foreach (var item in col)
                {
                    string ID = GetXMLElement("ID", "", item);
                    string Name = GetXMLElement("Name", "", item);

                    lst.Add(new Departments(ID, Name));
                }
            }
            return lst;
        }


        /// <summary>
        /// Получить все записи из XML для пользовтаеля Consultant
        /// </summary>
        /// <param name="puth"></param>
        public static ObservableCollection<AccountPercent> ReadPercents()
        {
            var lst = new ObservableCollection<AccountPercent>();
            if (File.Exists(Puth))
            {
                string xml = File.ReadAllText(Puth);
                var col = XDocument.Parse(xml).Descendants("AccountPercents").Descendants("Account").ToList();
                foreach (var item in col)
                {
                    string ID = GetXMLElement("ID", "", item);
                    string Date = GetXMLElement("Date", "", item);
                    string Number = GetXMLElement("Number", "", item);
                    string IDAccount = GetXMLElement("IDAccount", "", item);
                    string Ammount = GetXMLElement("Ammount", "", item);

                    AccountPercent str = new AccountPercent(ID, Date, Number, IDAccount, Ammount);
                    lst.Add(str);
                }
            }
            return lst;
        }


        /// <summary>
        /// Получить все записи из XML для пользовтаеля Consultant
        /// </summary>
        /// <param name="puth"></param>
        public static ObservableCollection<IAccounts<Accounts_1>> ReadAccounts()
        {
            var lst = new ObservableCollection<IAccounts<Accounts_1>>();
            if (File.Exists(Puth))
            {
                string xml = File.ReadAllText(Puth);
                var col = XDocument.Parse(xml).Descendants("Accounts").Descendants("Account").ToList();
                foreach (var item in col)
                {
                    string ID = GetXMLElement("ID", "", item);
                    string Number = GetXMLElement("Number", "", item);
                    string CustomerID = GetXMLElement("CustomerID", "", item);
                    string Ammount = GetXMLElement("Ammount", "", item);
                    string Rate = GetXMLElement("Rate", "", item);
                    string DateOpen = GetXMLElement("DateOpen", "", item);
                    string DateClose = GetXMLElement("DateClose", "", item);
                    string TypeOfAccount = GetXMLElement("TypeOfAccount", "", item);

                    if (TypeOfAccount.Equals("DepositAccount"))
                    {
                        IAccounts<Accounts_1> str = new DepositAccount(ID, Number, CustomerID, Ammount, Rate, DateOpen, DateClose, TypeOfAccount);
                        lst.Add(str);
                    }
                    else
                    {
                        IAccounts<Accounts_1> str = new NotDepositAccount(ID, Number, CustomerID, Ammount, Rate, DateOpen, DateClose, TypeOfAccount);
                        lst.Add(str);
                    }
                }
            }
            return lst;
        }


        /// <summary>
        /// Получить все записи из XML по Transfer
        /// </summary>
        public static ObservableCollection<TransferAccounts> ReadTransfers()
        {
            var lst = new ObservableCollection<TransferAccounts>();
            if (File.Exists(Puth))
            {
                string xml = File.ReadAllText(Puth);
                var col = XDocument.Parse(xml).Descendants("Transfers").Descendants("Account").ToList();
                foreach (var item in col)
                {
                    string ID = GetXMLElement("ID", "", item);
                    string Date = GetXMLElement("Date", "", item);
                    string CustomerID = GetXMLElement("CustomerID", "", item);
                    string AccountID = GetXMLElement("AccountID", "", item);
                    string Number = GetXMLElement("Number", "", item);
                    string AccountGetID = GetXMLElement("AccountGetID", "", item);
                    string NumberGet = GetXMLElement("NumberGet", "", item);
                    string Type = GetXMLElement("Type", "", item);
                    string Amount = GetXMLElement("Amount", "", item);

                    lst.Add(new TransferAccounts(ID, Date, CustomerID, AccountID, Number, AccountGetID, NumberGet, Type, Amount));
                }
            }
            return lst;
        }

        /// <summary>
        /// Получить все записи из XML по Turnovers
        /// </summary>
        public static ObservableCollection<AccountTurnover> ReadTurnOvers()
        {
            var lst = new ObservableCollection<AccountTurnover>();
            if (File.Exists("ListOfTurnOvers.xml"))
            {
                string xml = File.ReadAllText("ListOfTurnOvers.xml");
                var col = XDocument.Parse(xml).Descendants("AccountTurnover").Descendants("Account").ToList();
                foreach (var item in col)
                {
                    string AccountID = GetXMLElement("AccountID", "", item);
                    string Type = GetXMLElement("TypeOfTurnover", "", item);
                    string Amount = GetXMLElement("Amount", "", item);

                    lst.Add(new AccountTurnover(AccountID, Type, Amount));
                }
            }
            return lst;
        }


        /// <summary>
        /// Получить все записи из XML для пользовтаеля Consultant
        /// </summary>
        public static ObservableCollection<T> GetListFromFile()
        {
            ObservableCollection<T> lst = new ObservableCollection<T>();
            if (typeof(T) == typeof(Customers))
            {
                lst = ReadCustomers() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(Departments))
            {
                lst = ReadDepartments() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(Accounts_1))
            {
                lst = ReadAccounts() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(TransferAccounts))
            {
                lst = ReadTransfers() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(AccountTurnover))
            {
                lst = ReadTurnOvers() as ObservableCollection<T>;
            }
            return lst;
        }


    }
}
