﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper; //importando
using Projeto.Services.Mappings; //importando

namespace Projeto.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntityToViewModelMap>();
                cfg.AddProfile<ViewModelToEntityMap>();
            });
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
         //   chave de configuração - a API aceita requisições externas
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE"); //metodos
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization"); //cabeçalhos
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000"); // tamanho do trafego de dados
                HttpContext.Current.Response.End();
            }
        }

    }
}
