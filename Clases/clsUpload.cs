using Antlr.Runtime.Misc;
using AppSerWEB.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
namespace AppSerWEB
{
    public class clsUpload
    {
        public string Datos { get; set; }
        public string Proceso { get; set; }
        public HttpRequestMessage request { get; set; }
        private List<string> Archivos;
        public async Task<HttpResponseMessage> GrabarArchivo(bool actualizar)
        {
            if (!request.Content.IsMimeMultipartContent()) {
                return request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "no se envio un archivo para  procesar");
            }
            string root = HttpContext.Current.Server.MapPath("~/Archivos");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                bool existe = false;
                await request.Content.ReadAsMultipartAsync(provider);
                if (provider.FileData.Count > 0)
                {
                    Archivos = new List<string>();
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        string fileName = file.Headers.ContentDisposition.FileName;
                        if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                        {
                            fileName = fileName.Trim('"');
                        }

                        if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                        {
                            fileName = Path.GetFileName(fileName);
                        }
                        
                        if (File.Exists(Path.Combine(root, fileName)))
                        {
                            if (actualizar)
                            {
                                File.Delete(Path.Combine(root, fileName));
                                File.Move(file.LocalFileName, Path.Combine(root, fileName));
                                return request.CreateResponse(System.Net.HttpStatusCode.OK, "El archivo se actualizo correctamente");
                            }
                            else
                            {
                                File.Delete(Path.Combine(root, file.LocalFileName));
                                existe = true;
                            }
                        }
                        else {
                            if (!actualizar) {
                                existe = false;
                                Archivos.Add(fileName);
                                File.Move(file.LocalFileName, Path.Combine(root, fileName));
                            }
                            else{
                                return request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "El archivo no exite, debe agregarlo");
                            }
                        }
                    }
                    if (!existe) {
                        string RptaBD = ProcesarBD();
                        return request.CreateResponse(System.Net.HttpStatusCode.OK, "Archivo subido correctamente" +RptaBD);
                    }else
                    {
                        return request.CreateErrorResponse(System.Net.HttpStatusCode.Conflict, "El archivo ya existe en el servidor");
                    }
                }
                else
                {
                    return request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "No se envio un archivo para procesar");
                }
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public HttpResponseMessage DescargarArchivo(string Imagen)
        {
            try
            {
                string Ruta = HttpContext.Current.Server.MapPath("~/Archivos");
                string Archivo = Path.Combine(Ruta, Imagen);

                if (File.Exists(Archivo))
                {
                    HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    var stream = new FileStream(Archivo, FileMode.Open);
                    response.Content = new StreamContent(stream);
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = Imagen;
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                    return response;
                }
                else
                {
                    return request.CreateErrorResponse(System.Net.HttpStatusCode.NoContent, "No se encontró el archivo");
                }
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private string ProcesarBD()
        {
            switch (Proceso.ToUpper())
            {
                case "PRODUCTO":
                    clsProducto producto = new clsProducto();
                    return producto.GrabarImagenProducto( Convert.ToInt32(Datos), Archivos);
                default:
                return "Proceso no definido";
            }
        }
    }
}