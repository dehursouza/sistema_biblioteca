using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Biblioteca.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult ListaDeUsuarios()  //ok
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            return View(new UsuarioService().Listar());
        }

        public IActionResult editarUsuario(int id){   //ok
            UsuariosController u = (new UsuarioService().Listar(id));
            return View(u);
        }
        

        /*
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }
        */


        [HttpPost]
        public IActionResult editarUsuario(Usuario userEditado)
        {
            //Autenticacao.CheckLogin(this);

            UsuarioService us = new UsuarioService();
            us.editarUsuario(userEditado);
            return RedirectToAction("ListaDeUsuarios");
        }

        public IActionResult RegistrarUsuarios()  //ok
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View();
        }

        public IActionResult RegistrarUsuarios(Usuario novoUser)  //ok
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            novoUser.Senha = Criptografo.TextoCriptografado(novoUser.Senha);
            UsuarioService us = new UsuarioService();
            us.incluirUsuario(novoUser);

            return RedirectToAction("cadastroRealizado");
        }

        public IActionResult ExcluirUsuario(int id)
        {            
            return View(new UsuarioService().Listar(id));
        }

        
        public IActionResult ExcluirUsuario(string decisao int id)
        {
            if(decisao=="EXCLUIR"){
                ViewData["Mensagem"] = "Exclusão de Usuário " + new UsuarioService().Listar(id).nome + " realizada com sucesso";
                new UsuarioService().excluirUsuario(id);
                return View("ListaDeUsusarios", new UsuarioService().Listar());
                
            }else{
                ViewData["Mensagem"] = "Exclusão de cancelada";
                return View("ListaDeUsusarios", new UsuarioService().Listar());
            }            
            
        }
        public IActionResult cadastroRealizado(){
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View();
        }
        
        public IActionResult NeedAdmin(){
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Sair(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }





        /*

        public IActionResult Edicao(int id)
        {
            //Autenticacao.CheckLogin(this);

            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);
            return View(u);
        }


        
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioService UsuarioService = new UsuarioService();

            if(u.Id == 0)
            {
                UsuarioService.Inserir(u);
            }
            else
            {
                UsuarioService.Atualizar(u);
            }

            return RedirectToAction("Listagem");
        }

        
        public IActionResult Listagem(string tipoFiltro, string filtro)
        {
            Autenticacao.CheckLogin(this);
            FiltrosUsuarios objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosUsuarios();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            UsuarioService UsuarioService = new UsuarioService();
            return View(UsuarioService.ListarTodos(objFiltro));
        }
        

        public IActionResult Listagem(string tipoFiltro, string filtro, string itensPorPagina, int NumDaPagina, int PaginaAtual)
        {
            Autenticacao.CheckLogin(this);
            FiltrosUsuarios objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosUsuarios();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            
            ViewData["UsuariosPorPagina"]= (string.IsNullOrEmpty(itensPorPagina) ? 10 : Int32.parse(itensPorPagina));
            ViewData["PaginaAtual"] = (PaginaAtual !=0 ? PaginaAtual : 1);

            UsuarioService UsuarioService = new UsuarioService();
            return View(UsuarioService.ListarTodos(objFiltro));
        }


        

        */

    }
}