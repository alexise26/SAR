<%@ Page Title="" Language="C#" MasterPageFile="~/Views/masterpage.Master" AutoEventWireup="true" CodeBehind="frmCiclos.aspx.cs" Inherits="SAR.frmCiclos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="app">
        <div class="page-header page-header-default">
            <div class="page-header-content">
                <div class="page-title">
                    <h4><i class="icon-arrow-left52 position-left"></i><span class="text-semibold">Capturar </span>Ciclos</h4>
                </div>
            </div>
        </div>
        <div class="container-fluid" ng-controller="cicCtrl">
            <div class="row">
                <div class="col-xs-12 caja" style="margin-bottom: 5px;">
                    <h5><b>Nuevo ciclo</b></h5>
                </div>
                <div class="col-xs-12 caja">
                    <div class="col-xs-12 col-sm-3 first last">
                        <p>CLAVE DEL CICLO <span class="required-mark" ng-if="requerido == true">***</span></p>
                        <input type="text" class="form-control" value="" name="txtclave" ng-model="txtclave" placeholder="ej. PV2017"  required/>
                    </div>
                    <div class="col-xs-12 col-sm-3 first last">
                        <p>DESCRIPCIÓN DEL CICLO <span class="required-mark" ng-if="requerido == true">***</span></p>
                        <input type="text" class="form-control" value="" name="txtdesc" ng-model="txtdesc" placeholder="ej. PRIMAVERA-VERANO 2017" required/>
                    </div>
                    <div class="col-xs-12 col-sm-3 first last">
                        <p>FECHA DE INICIO</p>
                        <input type="date" class="form-control" value="" name="txtinicio" ng-model="txtinicio" placeholder="dd/mm/yyyy"  />
                    </div>
                    <div class="col-xs-12 col-sm-3 first last">
                        <p>FECHA DE FIN</p>
                        <input type="date" class="form-control" value="" name="txtfin" ng-model="txtfin" placeholder="dd/mm/yyyy" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 ">
                    <div class="col-xs-12 col-sm-6 first text-left">
                        <p  class="required-mark" ng-if="requerido == true">*** Campos requeridos</p>
                    </div>
                    <div class="col-xs-12 col-sm-3 first ">
                        <input type="submit" class="btn btn-warning btn-block" value="Reiniciar" name="btnreiniciar" />
                    </div>
                    <div class="col-xs-12 col-sm-3 first">
                        <input  class="btn btn-success btn-block" value="Guardar" ng-click="insertCiclo()" name="btnguardar" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 caja titulo" style="margin-bottom: 5px;">
                    <h5><b>Lista de ciclos</b></h5>
                    <div class="col-xs-12 col-sm-4 input-group">
                        <div class="form-group has-feedback">
                            <input type="text" placeholder="Buscar..." class="top20 right txt form-control m-right20" style="float: right;" ng-model="userSearch">
                            <span class="glyphicon glyphicon-search form-control-feedback top20 m-right20"></span>
                        </div>
                    </div>
                    <br />
                    <div class=" table-responsive" style="padding-bottom: 100px;">
                        <table class="table table-hover text-left">
                            <thead style="background-color: #28343a; color: white">
                                <tr>
                                    <th>CICLO</th>
                                    <th>DESC.</th>
                                    <th>INICIO</th>
                                    <th>FIN</th>
                                    <th>ESTATUS</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr ng-repeat="ciclo in ciclos | filter:userSearch">
                                    <td>{{ciclo.CICLO_CVE}}</td>
                                    <td>{{ciclo.CICLO_DES}}</td>
                                    <td>{{ciclo.FECHA_APERTURA | date : "dd.MM.y" }}</td>
                                    <td>{{ciclo.FECHA_CIERRE | date: "dd.MM.y" }}</td>
                                    <td ng-if="ciclo.ESTATUS_ID == 1">
                                        <div class="dropdown">
                                            <button class="btn btn-info dropdown-toggle btn-xs estatus-label" type="button" data-toggle="dropdown">{{ciclo.ESTATUS}}<span class="caret"></span></button>
                                            <ul class="dropdown-menu btn-xs">
                                                <li><a href="#">ABIERTO</a></li>
                                                <li><a href="#">CERRADO</a></li>
                                            </ul>
                                        </div>
                                    </td>
                                    <td ng-if="ciclo.ESTATUS_ID == 2">
                                        <div class="dropdown">
                                            <button class="btn btn-success dropdown-toggle btn-xs estatus-label" type="button" data-toggle="dropdown">{{ciclo.ESTATUS}}<span class="caret"></span></button>
                                            <ul class="dropdown-menu btn-xs">
                                                <li><a href="#">CERRADO</a></li>
                                            </ul>
                                        </div>
                                    </td>
                                    <td ng-if="ciclo.ESTATUS_ID == 3">
                                        <div class="dropdown">
                                            <button class="btn btn-danger dropdown-toggle btn-xs estatus-label" type="button" data-toggle="dropdown">{{ciclo.ESTATUS}}<span class="caret"></span></button>
                                            <ul class="dropdown-menu btn-xs">
                                                <li><a href="#"></a></li>
                                            </ul>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
