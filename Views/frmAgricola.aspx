<%@ Page Title="" Language="C#" MasterPageFile="~/Views/masterpage.Master" AutoEventWireup="true" CodeBehind="frmAgricola.aspx.cs" Inherits="SAR.frmAgricola" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="app">
        <div class="page-header page-header-default">
            <div class="page-header-content">
                <div class="page-title">
                    <h4><i class="icon-arrow-left52 position-left"></i><span class="text-semibold">Capturar </span>Solicitud Agrícola</h4>
                </div>
            </div>
        </div>
        <div class="container-fluid" ng-controller="solagCtrl">
            <div class="row">
                <div class="col-xs-12 caja" style="margin-bottom: 5px;">
                    <h5><b>Beneficiario</b></h5>
                </div>
                <div class="col-xs-12 caja">
                    <div class="col-xs-12 col-sm-3 first last">
                        <p>NOMBRE</p>
                        <div class="input-group">
                            <input type="text" action="none" class="form-control" ng-model="benNombre" placeholder="Presiona el botón para buscar" name="txtclave" readonly />
                            <span class="input-group-btn">
                                <button type="button" class="btn btn-default" data-toggle="modal" data-target="#modalBeneficiario">
                                    <i class="icon-search4"></i>
                                </button>
                            </span>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-3 first last">
                        <p>CURP</p>
                        <input type="text" class="form-control" ng-model="benCurp" value="" name="txtcurp" readonly />
                    </div>
                    <div class="col-xs-12 col-sm-3 first last">
                        <p>MUNICIPIO</p>
                        <input type="text" class="form-control" ng-model="benMun" value="" name="txtmun" readonly />
                    </div>
                    <div class="col-xs-12 col-sm-3 first last">
                        <p>LOCALIDAD</p>
                        <input type="text" class="form-control" ng-model="benLoc" value="" name="txtloc" readonly />
                    </div>
                </div>
            </div>
            <!-- inicio de datos generales -->
            <div class="row">
                <div class="col-xs-12 caja titulo" style="margin-bottom: 5px;">
                    <h5><b>Datos de Solicitud</b></h5>
                </div>
                <div class="col-xs-12 col-sm-4 caja">
                    <div class="col-xs-12 first ">
                        <p>BENEFICIARIO</p>
                        <input class="form-control" ng-model="benNombre" name="txtbenef" readonly />
                    </div>
                    <div class="col-xs-12">
                        <p>FOLIO</p>
                        <input class="form-control" type="text" value="" name="txtfolio" required />
                    </div>
                    <div class="col-xs-12">
                        <p>CICLO</p>
                        <select class="form-control" name="cboCiclo" ng-model="ciclo" ng-options="ciclo.CICLO_CVE for ciclo in ciclos">
                            <option value="">-- Selecciona --</option>
                        </select>
                    </div>
                    <div class="col-xs-12 last">
                        <p>TIPO DE SOLICITUD</p>
                        <select class="form-control" name="cbosolicitud" ng-model="tipoSoli" ng-options="tipoSoli.TIPO_SOLICITUD_DES for tipoSoli in tipo_solicitud">
                            <option value="">-- Selecciona --</option>
                        </select>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-4 caja">
                    <div class="col-xs-12 first">
                        <p>PRODUCTO</p>
                        <select class="form-control" name="cboprod" ng-model="producto" ng-options="producto.PRODUCTO_DES for producto in productos">
                            <option value="">-- Selecciona --</option>
                        </select>
                    </div>
                    <div class="col-xs-12">
                        <p>SUPERFICIE PROPIA O EJIDAL</p>
                        <input class="form-control" type="number" value="" name="txtpropia" required />
                    </div>
                    <div class="col-xs-12">
                        <p>SUPERFICIE EN RENTA</p>
                        <input class="form-control" type="number" value="" name="txtrenta" />
                    </div>
                    <div class="col-xs-12 last">
                        <p>TIPO DE AGRICULTURA</p>
                        <select class="form-control" name="cboagri" ng-model="tipoAgri" ng-options="tipoAgri.TIPO_AGR_DES for tipoAgri in tipo_agricultura">
                            <option value="">-- Selecciona --</option>
                        </select>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-4 caja">
                    <div class="col-xs-12 first">
                        <p>DAÑO 0-40%</p>
                        <input class="form-control" type="number" value="" name="txt040" required />
                    </div>
                    <div class="col-xs-12">
                        <p>DAÑO 41%-70%</p>
                        <input class="form-control" type="number" value="" name="txt4170" />
                    </div>
                    <div class="col-xs-12 ">
                        <p>DAÑO MÁS DE 70</p>
                        <input class="form-control" type="number" value="" name="txtmas70" required />
                    </div>
                    <div class="col-xs-12 last">
                        <p>OBSERVACIONES</p>
                        <input class="form-control" type="text" value="" name="txtobvs" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-offset-7 col-sm-5 ">
                    <div class="col-xs-12 col-sm-6 first ">
                        <input type="submit" class="btn btn-warning btn-block" value="Reiniciar" name="btnreiniciar" />
                    </div>
                    <div class="col-xs-12 col-sm-6 first">
                        <input type="submit" class="btn btn-success btn-block" value="Guardar" name="btnguardar" />
                    </div>
                </div>
            </div>
            <!-- modalBeneficiario -->
            <div class="modal fade" id="modalBeneficiario" role="dialog">
                <div class="modal-dialog modal-lg" style="width: 100%">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title text-center"><b>Lista de beneficiarios</b></h4>
                        </div>
                        <div class="modal-body">
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
                                            <th>NOMBRE</th>
                                            <th>CURP</th>
                                            <th>UPP</th>
                                            <th>MUNICIPIO</th>
                                            <th>LOCALIDAD</th>
                                            <th>OCUPACION</th>
                                            <th>TELEFONO</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr ng-repeat="beneficiario in beneficiarios | filter:userSearch">
                                            <td>{{beneficiario.NOMBRE}}</td>
                                            <td>{{beneficiario.CURP}}</td>
                                            <td>{{beneficiario.UPP}}</td>
                                            <td>{{beneficiario.MUNICIPIO}}</td>
                                            <td>{{beneficiario.LOCALIDAD}}</td>
                                            <td>{{beneficiario.OCUPACION}}</td>
                                            <td>{{beneficiario.TELEFONO | tel}}</td>
                                            <td>
                                                <button class="btn btn-success" data-dismiss="modal" type="button" ng-click="getBeneficiario(beneficiario.BENEFICIARIO_ID)">Select</button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
