using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClientEntities
    {
        public int ClientID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        
        //Entities המרה ממשתנה מהמסד נתונים למשתנה מסוג      
        public static ClientEntities ConvertClientTableToClientEntities(Client C)
        {
            ClientEntities C1 = new ClientEntities() { ClientID = C.ClientID, EmailAddress = C.EmailAddress, Password = C.Password };
            return C1;
        }

        //למשתנה מסוג המסד נתונים Entities המרה ממשתנה מסוג 
        public static Client ConvertClientEntitiesToClientTable(ClientEntities C)
        {
            Client C2 = new Client() { ClientID = C.ClientID, EmailAddress = C.EmailAddress, Password = C.Password };
            return C2;
        }

        //Entitiesקבלת רשימה מסוג המסד נתונים והמרת הרשימה ל
        public static List<ClientEntities> ConvertToListClientEntities(List<Client> ListC)
        {
            List<ClientEntities> ListC1 = new List<ClientEntities>();
            foreach (var item in ListC)
            {
                ListC1.Add(ConvertClientTableToClientEntities(item));
            }
            return ListC1;
        }

        //והמרת הרשימה למסד הנתונים Entitiesקבלת רשימה מסוג ה
        public static List<Client> ConvertToListClientTable(List<ClientEntities> ListC)
        {
            List<Client> ListC2 = new List<Client>();
            foreach (var item in ListC)
            {
                ListC2.Add(ConvertClientEntitiesToClientTable(item));
            }
            return ListC2;
        }
    }
}
