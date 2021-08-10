using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class DeliveryRoutesBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();

        //פונקציה השולפת רשימה
        public static List<DeliveryRoutesEntities> GetAllDeliveryRoutes()
        {
            List<DeliveryRoutes> DR = bl.DeliveryRoutes.ToList();
            return DeliveryRoutesEntities.ConvertToListDeliveryRoutesEntities(DR);
        }

        //פונקציה השולפת לפי קוד
        public static List<DeliveryRoutesEntities> GetIdDeliveryRoutes(int id)
        {

            List<DeliveryRoutes> listOrder = bl.DeliveryRoutes.Where(x => x.SendingCompanyID == id).ToList();
            List<DeliveryRoutes> listDate=new List<DeliveryRoutes>();

            int i = 1;
            foreach (var item in listOrder)
            {
                if(listOrder.Count()==i)
                {
                    if (listDate.Last().Date != item.Date)
                        listDate.Add(listOrder[i-1]);

                }
                else
                {
                    if (listOrder[i].Date == item.Date)
                        listDate.Add(listOrder[i-1]);
                    else
                        listDate.Add(listOrder[i-1]);
                }
                i++;
            }
            return DeliveryRoutesEntities.ConvertToListDeliveryRoutesEntities(listDate);
        }

        public static List<DeliveryRoutesEntities> GetListDeliveryRoutesByIDCompany(int id)
        {
            return DeliveryRoutesEntities.ConvertToListDeliveryRoutesEntities(bl.DeliveryRoutes.Where(x => x.SendingCompanyID == id && x.Date==DateTime.Today).ToList());
           
        }

        //פונקצית המוסיפה יום חדש
        public static int GetAddDeliveryRoutes(DeliveryRoutesEntities DR)
        {
            bl.DeliveryRoutes.Add(DeliveryRoutesEntities.ConvertDeliveryRoutesEntitiesToDeliveryRoutesTable(DR));
            bl.SaveChanges();
            var a = bl.DeliveryRoutes.Where(dr=>dr.Date==DR.Date && dr.SendingCompanyID==DR.SendingCompanyID).ToList() ;
           
            return a[a.Count-1].DeliveryRoutesID;
        }

        //פונקציה המעדכנת יום מהרשימה
        public static List<DeliveryRoutesEntities> GetUpdatDeliveryRoutes(DeliveryRoutesEntities DR)
        {
            bl.DeliveryRoutes.FirstOrDefault(x => x.DeliveryRoutesID == DR.DeliveryRoutesID).SendingCompanyID = DR.SendingCompanyID;
            bl.DeliveryRoutes.FirstOrDefault(x => x.DeliveryRoutesID == DR.DeliveryRoutesID).Date = DR.Date;
            bl.SaveChanges();
            return DeliveryRoutesEntities.ConvertToListDeliveryRoutesEntities(bl.DeliveryRoutes.ToList());
        }

        //פונקציה המסירה יום מהרשימה
        public static List<DeliveryRoutesEntities> GetRemoveDeliveryRoutes(int id)
        {
            var listDeliveryRoutes = bl.DeliveryRoutes.Where(x => x.DeliveryRoutesID == id);
            foreach (var item in listDeliveryRoutes)
            {
                bl.DeliveryRoutes.Remove(item);
            }
            bl.DeliveryRoutes.Remove(bl.DeliveryRoutes.FirstOrDefault(x => x.DeliveryRoutesID == id));
            bl.SaveChanges();
            return DeliveryRoutesEntities.ConvertToListDeliveryRoutesEntities(bl.DeliveryRoutes.ToList());
        }


        //פונקציה השולחת מייל לעובד
        public static int GetSendEmail(string email,List<string> sendListOrderToWorker)
        {
            var addreesMail = email;
            var list = sendListOrderToWorker;
            try
            {
                //for (int i = 0; i < list.Count(); i++)
                    SendEmailBL.SendMail( addreesMail, "שלום", " יש לך מסלול של שליחויות לעשות היום בהצלחה:)",list);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
