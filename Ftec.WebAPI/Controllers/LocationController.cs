using Ftec.WebAPI.Application;
using Ftec.WebAPI.Application.DTO;
using Ftec.WebAPI.Domain.Interfaces;
using Ftec.WebAPI.Infra.Repository;
using Ftec.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ftec.WebAPI.Controllers
{
    public class LocationController : ApiController
    {
        private ILocalRepository localRepository;
        private LocalApplication localApplication;
        // POST api/values

        public LocationController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            //injetando a dependencia do repositorio na aplicação
            localRepository = new LocalRepository(connectionString);
            localApplication = new LocalApplication(localRepository);
        }
        public HttpResponseMessage Post([FromBody]DadosLocal value)
        {            
            try
            {
                //Neste local faria a inclusao do cliente no repositorio
                //Antes de fazer a inclusão o cliente seria consistido
                //Se o cliente for inserido é de responsabilidade da API retornar o código do cliente gerado no processo de inclusão

                String id = Inserir(value);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ApplicationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private String Inserir(DadosLocal dl)
        {
            //executa o mapeamento
            LocalDTO localDTO = new LocalDTO()
            {
                Identificador = dl.Identificador,
                Latitude = dl.Latitude,
                Longitude = dl.Longitude,
                Altitude = dl.Altitude,
                Speed = dl.Speed,
                Accuracy = dl.Accuracy,
                Bearing = dl.Bearing,
                Data = dl.Data


            };

            return localApplication.Insert(localDTO);
        }
    }
}
