using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Tranzact.Infraestruture
{
    public class Logger : ILogger
    {
        private string _rutaNombreArchivo = "";
        private string _patronRegistro = "";
        private string _tamanioMaximo = "";
        private int _cantidadBackups;
        private static ILog _log { get; set; }
        private IConfiguration configuration;
        public Logger(IConfiguration iconfig)
        {
            Logger._log = LogManager.GetLogger(typeof(Logger));
            configuration = iconfig;
            _log = LogManager.GetLogger(typeof(Logger));
            _rutaNombreArchivo = configuration.GetSection("Logger").GetSection("LoggerNombreRutaArchivo").Value;
            _patronRegistro = configuration.GetSection("Logger").GetSection("LoggerPatronRegistro").Value;
            _tamanioMaximo = configuration.GetSection("Logger").GetSection("LoggerTamanioMaximo").Value;
            _cantidadBackups = int.Parse(configuration.GetSection("Logger").GetSection("LoggerCantidadBackups").Value);
            this.Configure();
        }

        public void Configure()
        {
            Hierarchy repository = (Hierarchy)LogManager.GetRepository(Assembly.GetEntryAssembly());
            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = this._patronRegistro;
            patternLayout.ActivateOptions();
            repository.Root.RemoveAllAppenders();
            RollingFileAppender rollingFileAppender = new RollingFileAppender();
            rollingFileAppender.AppendToFile = true;
            rollingFileAppender.File = this._rutaNombreArchivo;
            rollingFileAppender.Layout = (ILayout)patternLayout;
            rollingFileAppender.MaxSizeRollBackups = this._cantidadBackups;
            rollingFileAppender.RollingStyle = RollingFileAppender.RollingMode.Size;
            rollingFileAppender.MaximumFileSize = this._tamanioMaximo;
            rollingFileAppender.StaticLogFileName = true;
            rollingFileAppender.ActivateOptions();
            repository.Root.AddAppender((IAppender)rollingFileAppender);
            MemoryAppender memoryAppender = new MemoryAppender();
            memoryAppender.ActivateOptions();
            repository.Root.AddAppender((IAppender)memoryAppender);
            repository.Root.Level = Level.Info;
            repository.Configured = true;
        }
        public void Info(object message) => Logger._log.Info(message);
    }
}
