<%@ Page Title="" Language="C#" MasterPageFile="~/Views/masterpage.Master" AutoEventWireup="true" CodeBehind="frmProductos.aspx.cs" Inherits="SAR.frmProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="app">
        <div class="page-header page-header-default">
			<div class="page-header-content">
				<div class="page-title">
					<h4><i class="icon-arrow-left52 position-left"></i> <span class="text-semibold">Capturar </span>Productos Agrículas para Apoyos</h4>
			    </div>
            </div>
        </div>
        <div class="container-fluid" ng-controller="prdCtrl">
            <div class="row">
                <div class="col-xs-12 caja" style="margin-bottom:5px;">
                    <h5><b>Nuevo Producto</b></h5>
                </div>
                <div class="col-xs-12 caja">
                    <div class="col-xs-12 col-sm-4 first last">
                        <p>NOMBRE PRODUCTO</p>
                        <input type="text"  class="form-control" value="" name="txtproducto" required />
                    </div>
                    <div class="col-xs-12 col-sm-4 first last">
                        <p>OFICIO APROBACIÓN</p>
                        <input type="text"  class="form-control" value="" name="txtoficio" required/>
                    </div>
                    <div class="col-xs-12 col-sm-4 first last">
                        <p>APORTACIÓN PORDUCTORES</p>
                        <input type="number" step="0.01"  class="form-control" value="" name="txtproductores"  required/>
                    </div>
                    <div class="col-xs-12 col-sm-4 first last">
                        <p>APORTACIÓN GOBIERNO</p>
                        <input type="number" step="0.01" class="form-control" value="" name="txtgobierno"  required/>
                    </div>
                    <div class="col-xs-12 col-sm-4 first last">
                        <p>FECHA DE RECIBIDO EN PLANEACIÓN</p> 
                        <input type="date"  class="form-control" value="" name="txtplaneacion" placeholder="dd/mm/yyyy" required/>
                    </div>
                    <div class="col-xs-12 col-sm-4 first last">
                        <p>CICLO</p>
                        <select  class="form-control"  name="cbociclo" ng-model="ciclo" ng-options="ciclo.CICLO_CVE for ciclo in ciclos">
                            <option value="">-- Selecciona --</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-offset-7 col-sm-5 ">
                     <div class="col-xs-12 col-sm-6 first ">
                        <input type="submit" class="btn btn-warning btn-block" value="Reiniciar"  name="btnreiniciar"/>
                    </div>
                    <div class="col-xs-12 col-sm-6 first">
                        <input type="submit" class="btn btn-success btn-block" value="Guardar" name="btnguardar" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 caja titulo" style="margin-bottom:5px;">
                    <h5><b>Lista de Productos</b></h5>
                    <div class="col-xs-12 col-sm-4 input-group">
                        <div class="form-group has-feedback">
                            <input type="text" placeholder="Buscar..." class="top20 right txt form-control m-right20" style="float: right;" ng-model="userSearch">
                            <span class="glyphicon glyphicon-search form-control-feedback top20 m-right20"></span>
                        </div>
                    </div>
                    <br />
                    <div class=" table-responsive"  style="padding-bottom:100px;">
                        <table class="table table-hover text-left">
                        <thead style="background-color:#28343a; color:white">
                            <tr>
                                <th>PRODUCTO</th>
                                <th>OFICIO</th>
                                <th>PRODUCTORES</th>
                                <th>GOBIERNO</th>
                                <th>FECHA PLANEACIÓN</th>
                                <th>CICLO</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="producto in productos | filter:userSearch">
                                <td>{{producto.PRODUCTO_DES}}</td>
                                <td>{{producto.OFICIO_APROBACION}}</td>
                                <td>{{producto.APORTACION_PRODUCTORES | currency}}</td>
                                <td>{{producto.APORTACION_GOBIERNO | currency}}</td>
                                <td>{{producto.FECHA_RECIBIDO_PLANEA | date: "dd.MM.y"}}</td>
                                <td>{{producto.CICLO}}</td>
                            <td>
                                <button class="btn btn-danger" style="color:white"><b>X</b></button>
                            </td>
                            </tr>
                        </tbody>
                    </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
