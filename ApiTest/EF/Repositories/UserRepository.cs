using ApiTest.EF.Interfaces;
using ApiTest.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ApiTest.EF.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<int?> Add(User user)
        {
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@txt_user", Value = user.Txt_user },
                    new SqlParameter { ParameterName = "@txt_password", Value = user.Txt_password},
                    new SqlParameter { ParameterName = "@txt_nombre", Value = user.Txt_nombre},
                    new SqlParameter { ParameterName = "@txt_apellido", Value = user.Txt_apellido},
                    new SqlParameter { ParameterName = "@nro_doc", Value = user.Nro_doc},
                    new SqlParameter { ParameterName = "@cod_rol", Value = user.Cod_rol},
                    new SqlParameter { ParameterName = "@sn_activo", Value = user.sn_activo},
                    new SqlParameter { ParameterName = "@new_identity", Value = SqlDbType.Int},
                };

                var result = await Add(parms, "Exec [dbo].[CreateUser] @txt_user, @txt_password, @txt_nombre , @txt_apellido, @nro_doc, @cod_rol, @sn_activo, @new_identity");

                return result;
            }
            catch (System.Exception ex)
            {

                throw;
            }
          
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                //TODO: Mover a un sp
                var resp = await GetBy("Select * from dbo.tUsers", (x => x.Cod_usuario == id));

                return resp;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await GetAll(@"Exec dbo.Users_GetAll");
        }

        public void Update(int id, User user)
        {
            try
            {
                //TODO: Mover a un sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@id", Value = id},
                    new SqlParameter { ParameterName = "@txt_user", Value = user.Txt_user },
                    new SqlParameter { ParameterName = "@txt_password", Value = user.Txt_password},
                    new SqlParameter { ParameterName = "@txt_nombre", Value = user.Txt_nombre},
                    new SqlParameter { ParameterName = "@txt_apellido", Value = user.Txt_apellido},
                    new SqlParameter { ParameterName = "@nro_doc", Value = user.Nro_doc},
                    new SqlParameter { ParameterName = "@cod_rol", Value = user.Cod_rol},
                    new SqlParameter { ParameterName = "@sn_activo", Value = user.sn_activo},
                };

                 Update("Exec [dbo].[UpdateUser] @id, @txt_user, @txt_password, @txt_nombre , @txt_apellido, @nro_doc, @cod_rol, @sn_activo", parms);

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<User> Login(string user, string password)
        {
            //TODO: Generar token, hash etc
            var resp = await GetBy("Select * from dbo.tUsers", (x => x.Txt_user == user && x.Txt_password == password));

            return resp;
        }
    }
}
