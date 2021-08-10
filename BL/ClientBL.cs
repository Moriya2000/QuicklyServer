using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class ClientBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקצית המוסיפה לקוח חדש
        public static List<ClientEntities> GetAddClient(ClientEntities C)
        {
            //C.ClientID = bl.Client.Count() + 1;
            bl.Client.Add(ClientEntities.ConvertClientEntitiesToClientTable(C));
            bl.SaveChanges();
            return ClientEntities.ConvertToListClientEntities(bl.Client.ToList());
        }

        //פונקציה השולפת רשימה
        public static List<ClientEntities> GetAllClient()
        {
            List<Client> C = bl.Client.ToList();
            return ClientEntities.ConvertToListClientEntities(C);
        }

        //פונקציה השולפת לקוח לפי קוד
        public static ClientEntities GetIdClient(int id)
        {
            Client C1 = bl.Client.FirstOrDefault(x => x.ClientID == id);
            return ClientEntities.ConvertClientTableToClientEntities(C1);
        }

        //פונקציה המעדכנת לקוח מהרשימה
        public static List<ClientEntities> GetUpdatClient(ClientEntities C)
        {
            bl.Client.FirstOrDefault(x => x.ClientID == C.ClientID).EmailAddress = C.EmailAddress;
            bl.Client.FirstOrDefault(x => x.ClientID == C.ClientID).Password = C.Password;
            bl.SaveChanges();
            return ClientEntities.ConvertToListClientEntities(bl.Client.ToList());
        }

        //פונקציה המסירה לקוח מהרשימה
        public static List<ClientEntities> GetRemoveClient(int id)
        {
            var listClient = bl.Client.Where(x => x.ClientID == id);
            foreach (var item in listClient)
            {
                bl.Client.Remove(item);
            }
            bl.Client.Remove(bl.Client.FirstOrDefault(x => x.ClientID == id));
            bl.SaveChanges();
            return ClientEntities.ConvertToListClientEntities(bl.Client.ToList());
        }

        //פונקציה הבודקת האם לקוח קיים לפי כתובת מייל וסיסמא
        public static int GetEmailAddressPassword(string EmailAddress, string Password)
        {
            if ((bl.Client.Where(x => x.EmailAddress == EmailAddress && x.Password == Password).Count() != 0))
                return 1;
            return 0;
        }

        //פונקציה השולפת קוד משתמש וסיסמא
        public static int GetEmailAddressPasswordID(string EmailAddress, string Password)
        {
            return bl.Client.First(x => x.EmailAddress == EmailAddress && x.Password == Password).ClientID;
        }
    }
}
