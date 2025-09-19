using Microsoft.EntityFrameworkCore;
using MyMvcReactApp.Core.UserData.Objects;

namespace MyMvcReactApp.Core.UserData.Services
{

    public class UserService :IUserDataService
    {
        private readonly AppDbContext dbContext;

        public UserService(AppDbContext context)
        {
            dbContext = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            
            
            var users = await (from user in dbContext.Users
                               select new User
                               {
                                   Id = user.Id,
                                   Name = user.Name,
                                   Email = user.Email
                               })
                               .AsNoTracking()
                               .ToListAsync();

            return users;
        }

        public async Task <User?> GetUserByEmail(string email)
        {
            var emailuser= await(from user in dbContext.Users
                            where user.NormalizedEmail == email.ToUpper()
                            select new User
                            { 
                                  Id = user.Id,
                                  Name = user.Name
                            }).AsNoTracking().FirstOrDefaultAsync().ConfigureAwait(false);    
            return emailuser;
        }

        public async Task<User?> GetUserById(int id)
        {
              var Iduser   =  await(from user in dbContext.Users
                                  where user.Id == id
                                  select new User
                                  {
                                      Id = user.Id,
                                      Name = user.Name
                                  }).AsNoTracking().FirstOrDefaultAsync().ConfigureAwait(false);
            return Iduser;
        }
        public async Task<bool> AddUserAsync(string name,string useremail)
        {
            bool result = false;

            var newUser = new User
            {
                Name = name,
                Email = useremail,
                NormalizedEmail = useremail.ToUpper(),
            };

            try
            {
                 _ = dbContext.Users.Add(newUser);

                 _ = await dbContext.SaveChangesAsync().ConfigureAwait(false);

                 result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}