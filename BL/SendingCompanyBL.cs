using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class SendingCompanyBL
    {
        public static QuicklyEntities bl = new QuicklyEntities();
        public static List<SendingCompanyEntities> Scheduling()
        {
            DateTime currentTime = DateTime.Now;
            DateTime future = currentTime.AddDays(1).Date;
            int idCityG;
            int idCityT;

            //רשימת משלוחים שעדיין לא שובצו
            List<OrderEntities> list1 = OrderBL.GetAllOrder().Where(x => x.SentOrNot == false).ToList();
            //רשימת משלוחים חשובים למחר
            List<OrderEntities> list2 = list1.Where(x => (x.OrderDate.AddDays(x.Days)).Date == future).ToList();
            //רשימת חברות
            List<BusinessDaysEntities> list3 = BusinessDaysBL.GetAllDays().Where(x => x.Day == (int)future.DayOfWeek).ToList();
            //רשימת החברות המתאימות למשלוח מסוים
            List<BusinessDaysEntities> list4 = new List<BusinessDaysEntities>();
            //רשימה חברות וערים בהן הן עובדות
            List<CitiesCompanyEntities> listCities = new List<CitiesCompanyEntities>();
            //רשימה שעוברת על הסוגי רכבים שיש לחברה
            List<CarsCompanyEntities> listCar = new List<CarsCompanyEntities>();

            List<SendingCompanyEntities> list5 = new List<SendingCompanyEntities>();
            bool flag = false;

            //עובר על המשלוחים הדחופים - למחר
            foreach (var item in list2)
            {
                flag = false;
                //שומר את הקוד עיר של הכתובת יעד
                idCityG = item.CityGiving.CityID;
                //שומר את הקוד עיר של הכתובת מקור
                idCityT = item.CityTaking.CityID;

                //עובר על רשימת החברות המתאימות ובודק למי יש יתרון
                for (int i = 0; i < list5.Count(); i++)
                {
                    listCar = CarsCompanyBL.GetIdCarsCompany(list5[i].SendingCompanyID);
                    if (listCar.Exists(x => x.MaxVolume >= item.Volume))
                    {
                        for (int x = 0; x < list5[i].lo.Count; x++)
                        {
                            if ((list5[i].lo[x][0].CityTaking.CityID == idCityT && list5[i].lo[x][0].CityGiving.CityID == idCityG )||(list5[i].lo[x][0].CityTaking.CityID == idCityG && list5[i].lo[x][0].CityGiving.CityID == idCityT))
                            {
                                list5[i].lo[x].Add(item);
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag == true)
                        break;
                }
                if (flag != true)
                {
                    //עובר על רשימת החברות
                    foreach (var item1 in list3)
                    {
                        //שולח לפונקציית שליפה את הקוד חברה שתשלוף את הערים שעובדת
                        listCities = CitiesCompanyBL.GetIdCitiesCompany(item1.SendingCompanyID);
                        //שולח לפונקציית שליפה את הקוד חברה שתשלוף את הרכבים שיש לה
                        listCar = CarsCompanyBL.GetIdCarsCompany(item1.SendingCompanyID);
                        //בדיקה האם הערים שיש לחברה תואמים עיר של יעד וגם עיר מקור
                        if (listCities.Exists(x => x.CityID == idCityT) && (listCities.Exists(x => x.CityID == idCityG)))
                        {
                            //בדיקה האם נפח הרכב גדול מנפח המשלוח
                            if (listCar.Exists(x => x.MaxVolume >= item.Volume))
                            {
                                //אם כן מכניס לרשימת חברות מתאימות
                                if (!list5.Exists(x => x.SendingCompanyID == item1.SendingCompanyID))
                                    list5.Add(SendingCompanyBL.GetIdSendingCompany(item1.SendingCompanyID));
                                List<OrderEntities> l = new List<OrderEntities>();
                                l.Add(item);
                                list5.First(x => x.SendingCompanyID == item1.SendingCompanyID).lo.Add(l);
                                break;
                            }
                        }
                    }
                }
            }
            list2 = list1.Where(x => x.OrderDate.AddDays(x.Days) > future).ToList();
            foreach (var item in list2)
            {
                flag = false;
                //שומר את הקוד עיר של הכתובת יעד
                idCityG = item.CityGiving.CityID;
                //שומר את הקוד עיר של הכתובת מקור
                idCityT = item.CityTaking.CityID;

                //עובר על רשימת החברות המתאימות ובודק למי יש יתרון
                for (int i = 0; i < list5.Count(); i++)
                {
                    listCar = CarsCompanyBL.GetIdCarsCompany(list5[i].SendingCompanyID);
                    if (listCar.Exists(x => x.MaxVolume >= item.Volume))
                    {
                        for (int x = 0; x < list5[i].lo.Count; x++)
                        {
                            if ((list5[i].lo[x][0].CityTaking.CityID == idCityT && list5[i].lo[x][0].CityGiving.CityID == idCityG)||(list5[i].lo[x][0].CityTaking.CityID == idCityG && list5[i].lo[x][0].CityGiving.CityID == idCityT))
                            {
                                list5[i].lo[x].Add(item);
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag == true)
                        break;
                }
            }

            //for (int i = 0; i < list5.Count; i++)
            //{
            //    double bigest = list5[i].lo.Max(x => x.Volume);
            //    listCar = CarsCompanyBL.GetIdCarsCompany(list5[i].SendingCompanyID);
            //    list5[i].car = listCar.First(x => x.MaxVolume>=bigest );
            //}

            try
            {
                foreach (var company in list5)
                {
                    int idRoute = 0;
                    foreach (var route in company.lo)
                    {
                        idRoute = DeliveryRoutesBL.GetAddDeliveryRoutes(new DeliveryRoutesEntities() { SendingCompanyID = company.SendingCompanyID, Date = DateTime.Today });
                        foreach (var order in route)
                            DestinationsRouteBL.GetAddDestinationsRoute(new DestinationsRouteEntities() { DeliveryRoutesID = idRoute, OrderID = order.OrderID });
                    }
                }
                //הכנסת הנתונים לDB 
                // return list5;
            }
            catch (Exception e)
            {

            }
            List<string> a = new List<string>();
            List<OrderEntities> listOrder = new List<OrderEntities>();
            //שליחת מייל לאנשים שהחבילה שלהם שובצה היום
            foreach (var item in list5)
            {
                foreach (var item1 in item.lo)
                {
                    listOrder.AddRange(item1);
                }
            }
            foreach (var item in listOrder)
            {
                var addreesMail =TakingDeliveryBL.GetAddressMailByOrderID(item.OrderID);
                try
                {            
                  SendEmailBL.SendMail(addreesMail,"שלום"," השליח של quickly יגיע היום לאסוף את המשלוח, יום טוב:)",a);
                }catch(Exception e)
                {

                }

                addreesMail = GivingDeliveryBL.GetAddressMailByOrderID(item.OrderID);
                try
                {
                    SendEmailBL.SendMail(addreesMail, "שלום", " השליח של quickly יגיע היום להביא את המשלוח, יום טוב:)",a);
                }
                catch (Exception e)
                {

                }
            }
            List<int> listCompany = new List<int>();

            foreach (var itemIdCompany in list5)
            {
                listCompany.Add(itemIdCompany.SendingCompanyID);
            }
            foreach (var itemCompany in listCompany)
            {
                var addreesMail = GetAddressMailByOrderID(itemCompany);
                try
                {
                    SendEmailBL.SendMail(addreesMail, "שלום", 
                        "quickly שובצו לך שליחויות, הינך יכול להכנס לאתר שלנו כעת ולחלק בין העובדים שלך את השליחויות שיש, בהצלחה ויום טוב:)", a);
                }
                catch (Exception e)
                {

                }
            }

            return list5;
        }

        //שליחת מייל לחברות שליחויות ששובצו להם משלוחים
        public static string GetAddressMailByOrderID(int companyID)
        {
            try
            {
                var company = bl.SendingCompany.FirstOrDefault(c => c.SendingCompanyID == companyID);
                return company.Email;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        //פונקציה השולפת רשימה
        public static List<SendingCompanyEntities> GetAllSendingCompany()
       {
            List<SendingCompany> SC = bl.SendingCompany.ToList();
            return SendingCompanyEntities.ConvertToListSendingCompanyEntities(SC);
        }

        //פונקציה השולפת את כל הפרטים של החברת שליחויות לפי קוד
        public static AllDetailsCompany GetIdAllDetailsCompany(int companyNumber)
        {
            int id;
            var c = GetAllSendingCompany().FirstOrDefault(x => x.CompanyNumber == companyNumber);
            if (c == null)//אם לא נמצאה חברה עם קוד חברה זה
                return null;
            id = c.SendingCompanyID;

            //פרטיים אישיים על החברה
            AllDetailsCompany allDetailsCompany = new AllDetailsCompany();
            var companyDetails= GetIdSendingCompany(id);
            allDetailsCompany.CompanyName = companyDetails.CompanyName;
            allDetailsCompany.CompanyNumber = companyDetails.CompanyNumber;
            allDetailsCompany.Password = companyDetails.Password;
            allDetailsCompany.Phone = companyDetails.Phone;
            allDetailsCompany.Email = companyDetails.Email;
            allDetailsCompany.FullAddress = companyDetails.FullAddress;
            
            //פרטיים הבנק של החברה
            var bankDetails = CompanyBankDetailsBL.GetIdCompanyBankDetails(id);
            allDetailsCompany.Bank = bankDetails.Bank;
            allDetailsCompany.Branch = bankDetails.Branch;
            allDetailsCompany.AccountNumber = bankDetails.AccountNumber;
            allDetailsCompany.BeneficiaryName = bankDetails.BeneficiaryName;
            
            //סוגי רכבים
            allDetailsCompany.listCarsCompany =  CarsCompanyBL.GetIdCarsCompany(id);
            //ערים
            allDetailsCompany.listCitiesCompany= CitiesCompanyBL.GetIdCitiesCompany(id);
            //ימי עבודה
            allDetailsCompany.listBusinessDays= BusinessDaysBL.GetIdBusinessDays(id);
           
           
            return allDetailsCompany;
        }

        //שליפה של הפרטיים האישיים
        public static SendingCompanyEntities GetIdSendingCompany(int id)    
        {
            SendingCompany SC1 = bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID == id);
            return SendingCompanyEntities.ConvertSendingCompanyTableToSendingCompanyEntities(SC1);
        }

        //פונקציה שמוסיפה את כל פרטי החברה
        public static void GetAddAllDetailsCompany(AllDetailsCompany SC)
        {
            //פרטי הבנק של החברה
            CompanyBankDetailsEntities companyBankDetailsB = new CompanyBankDetailsEntities();
            companyBankDetailsB.CompanyBankDetailsID = SC.CompanyBankDetailsID;
            companyBankDetailsB.SendingCompanyID = SC.SendingCompanyID;
            companyBankDetailsB.BeneficiaryName = SC.BeneficiaryName;
            companyBankDetailsB.Bank = SC.Bank;
            companyBankDetailsB.Branch = SC.Branch;
            companyBankDetailsB.AccountNumber = SC.AccountNumber;

            //פרטיים אישיים על החברה
            SendingCompanyEntities sendingCompanyC = new SendingCompanyEntities();
            sendingCompanyC.SendingCompanyID = SC.CompanyBankDetailsID;
            sendingCompanyC.CompanyName = SC.CompanyName;
            sendingCompanyC.FullAddress = SC.FullAddress;
            sendingCompanyC.Phone = SC.Phone;
            sendingCompanyC.Email = SC.Email;
            sendingCompanyC.CompanyNumber = SC.CompanyNumber;
            sendingCompanyC.Password = SC.Password;

            int id = GetAddSendingCompany(sendingCompanyC).Last().SendingCompanyID;

            //ימים שבהם החברה עובדת
            foreach (var item in SC.listBusinessDays)
            {
                item.SendingCompanyID = id;
                BusinessDaysBL.GetAddDay(item);
            }
            List<CityEntities> allCity = CityBL.GetAllCity();
            //ערים שבהם החברה עובדת
            foreach (var item in SC.listCitiesCompany)
            {
                item.SendingCompanyID = id;
                var city = allCity.FirstOrDefault(c=> item.nameCity.Contains( c.CityName));
                if (city != null)
                    item.CityID = city.CityID;
                else
                {
                var addCityReturn = CityBL.GetAddCity(new CityEntities() { CityID = 0, CityName = item.nameCity });
                item.CityID = addCityReturn[0].CityID;
                 }
                CitiesCompanyBL.GetAddCitiesCompany(item);
            }

            //סוגי רכבים שיש לחברה
            foreach (var item in SC.listCarsCompany)
            {
                item.SendingCompanyID = id;
                CarsCompanyBL.GetAddCarsCompany(item);
            }

            companyBankDetailsB.SendingCompanyID = id;
            CompanyBankDetailsBL.GetAddCompanyBankDetails(companyBankDetailsB);
        }

        //פונקצית המוסיפה חברת שליחויות חדשה
        public static List<SendingCompanyEntities> GetAddSendingCompany(SendingCompanyEntities SC)
        {
            var aa = SendingCompanyEntities.ConvertSendingCompanyEntitiesToSendingCompanyTable(SC);
            bl.SendingCompany.Add(aa);
            bl.SaveChanges();
            return SendingCompanyEntities.ConvertToListSendingCompanyEntities(bl.SendingCompany.ToList());
        }

        //פונקציה המעדכנת חברת שליחויות מהרשימה
        public static void GetUpdatSendingCompany1(AllDetailsCompany SC)
        {
            //פרטים איישים על החברה
            SendingCompanyEntities sendingCompany = new SendingCompanyEntities();
            sendingCompany.SendingCompanyID = SC.SendingCompanyID;
            sendingCompany.CompanyName = SC.CompanyName;
            sendingCompany.FullAddress = SC.FullAddress;
            sendingCompany.Phone = SC.Phone;
            sendingCompany.Email = SC.Email;
            sendingCompany.CompanyNumber = SC.CompanyNumber;
            sendingCompany.Password = SC.Password;
            GetUpdatSendingCompany(sendingCompany);

            //פרטי בנק החברה
            CompanyBankDetailsEntities companyBankDetails = new CompanyBankDetailsEntities();
            companyBankDetails.SendingCompanyID = SC.SendingCompanyID;

            companyBankDetails.AccountNumber = SC.AccountNumber;
            companyBankDetails.Bank = SC.Bank;
            companyBankDetails.BeneficiaryName = SC.BeneficiaryName;
            companyBankDetails.Branch = SC.Branch;
            CompanyBankDetailsBL.GetUpdatCompanyBankDetails(companyBankDetails);

            int id = SC.CompanyBankDetailsID;

            //ימים שבהם החברה עובדת
            foreach (var item in SC.listBusinessDays)
            {
                item.SendingCompanyID = id;
                BusinessDaysBL.GetUpdatDay(item);
            }

            List<CityEntities> allCity = CityBL.GetAllCity();
            //ערים שבהם החברה עובדת
            foreach (var item in SC.listCitiesCompany)
            {
                item.SendingCompanyID = id;
                var city = allCity.FirstOrDefault(c => item.nameCity.Contains(c.CityName));
                if (city != null)
                    item.CityID = city.CityID;
                else
                {
                    var updateCityReturn = CityBL.GetUpdatCity(new CityEntities() { CityID = 0, CityName = item.nameCity });
                    item.CityID = updateCityReturn[0].CityID;
                }
                CitiesCompanyBL.GetUpdatCitiesCompany(item);
            }

            //סוגי רכבים שיש לחברה
            foreach (var item in SC.listCarsCompany)
            {
                item.SendingCompanyID = id;
                CarsCompanyBL.GetUpdatCarsCompany(item);
            }
        }


        //פונקציה המעדכנת חברת שליחויות מהרשימה
        public static List<SendingCompanyEntities> GetUpdatSendingCompany(SendingCompanyEntities SC)
        {
            try
            {
                //פרטים איישים על החברה
                bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID == SC.SendingCompanyID).CompanyName = SC.CompanyName;
                bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID == SC.SendingCompanyID).FullAddress = SC.FullAddress;
                bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID == SC.SendingCompanyID).Phone = SC.Phone;
                bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID == SC.SendingCompanyID).Email = SC.Email;
                bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID == SC.SendingCompanyID).CompanyNumber = SC.CompanyNumber;
                bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID == SC.SendingCompanyID).Password = SC.Password;
                bl.SaveChanges();
                return SendingCompanyEntities.ConvertToListSendingCompanyEntities(bl.SendingCompany.ToList());
            }
            catch(Exception e)
            {
                return null;
            }

        }

        //פונקציה המסירה חברת שליחויות מהרשימה
        public static List<SendingCompanyEntities> GetRemoveSendingCompany(int CompanyNumber)
        {
            int id;
            var c = bl.SendingCompany.FirstOrDefault(x => x.CompanyNumber == CompanyNumber);
            if (c == null)//אם לא נמצאה חברה עם קוד חברה זה
                return null;
            id = c.SendingCompanyID;

            var listBusinessDay = bl.BusinessDays.Where(x => x.SendingCompanyID == id);
            foreach(var item in listBusinessDay)
            {
                bl.BusinessDays.Remove(item);
            }

            var listCarsCompany = bl.CarsCampany.Where(x => x.SendingCompanyID == id);
            foreach (var item in listCarsCompany)
            {
                bl.CarsCampany.Remove(item);
            }


            var listCityCompany = bl.CitiesCompany.Where(x => x.SendingCompanyID == id);
            foreach (var item in listCityCompany)
            {
                bl.CitiesCompany.Remove(item);
            }

            bl.CompanyBankDetails.Remove(bl.CompanyBankDetails.FirstOrDefault(x => x.SendingCompanyID == id));

            bl.SendingCompany.Remove(bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID == id));

            bl.SaveChanges();
            return SendingCompanyEntities.ConvertToListSendingCompanyEntities(bl.SendingCompany.ToList());
        }

        //פונקציה הבודקת האם לקוח קיים לפי קוד חברה וסיסמא
        public static int GetCompanyNumberPassword(int CompanyNumber, string Password)
        {
            var companyNP = bl.SendingCompany.FirstOrDefault(x => x.CompanyNumber == CompanyNumber && x.Password == Password);
            if(companyNP != null)
                return companyNP.SendingCompanyID;
            return 0;
            //if ((bl.SendingCompany.FirstOrDefault(x => x.CompanyNumber == CompanyNumber && x.Password == Password) != null))
            //    return 1;
            //return 0;
        }

        //public static SendingCompanyEntities GatAllSendingCompanyByNumberPassword(int CompanyNumber, string Password)
        //{
        //  return  SendingCompanyEntities.ConvertSendingCompanyTableToSendingCompanyEntities(bl.SendingCompany.FirstOrDefault(x => x.CompanyNumber == CompanyNumber && x.Password == Password));


        //}
        
        public static SendingCompanyEntities GatAllSendingCompanyByNumberPassword(int SendingCompanyID)
        {
            return SendingCompanyEntities.ConvertSendingCompanyTableToSendingCompanyEntities(bl.SendingCompany.FirstOrDefault(x => x.SendingCompanyID==SendingCompanyID));


        }

    }
}