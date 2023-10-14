using BuhUchetApi.Models.MainThingModels;
using System.Threading.Tasks;
using static BuhUchetApi.Models.Enums;

namespace BuhUchetApi.Services.MainThingServices
{
    public class GroupInfoService
    {
        public async Task<GroupInfo> GetInfo(Groups group)
        {
            var response = new GroupInfo();
            if (group == Groups.First)
            {
                response.Name = "Первая";
                response.Time = 2;
            }
            else if (group == Groups.Second)
            {
                response.Name = "Вторая";
                response.Time = 3;
            }
            else if (group == Groups.Third)
            {
                response.Name = "Третьяя";
                response.Time = 5;
            }
            else if (group == Groups.Fourth)
            {
                response.Name = "Четвертая";
                response.Time = 7;
            }
            else if (group == Groups.Fiveth)
            {
                response.Name = "Пятая";
                response.Time = 10;
            }
            else if (group == Groups.Sixth)
            {
                response.Name = "Шестая";
                response.Time = 15;
            }
            else if (group == Groups.Seventh)
            {
                response.Name = "Седьмая";
                response.Time = 20;
            }
            else if (group == Groups.Eighth)
            {
                response.Name = "Восьмая";
                response.Time = 25;
            }
            else if (group == Groups.Nineth)
            {
                response.Name = "Девятая";
                response.Time = 30;
            }
            else if (group == Groups.Tenth)
            {
                response.Name = "Десятая";
                response.Time = 40;
            }

            return response;
        }
    }
}
