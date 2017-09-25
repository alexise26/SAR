<%@ Page Title="" Language="C#" MasterPageFile="~/Views/masterpage.Master" AutoEventWireup="true" CodeBehind="frmBeneficiarios.aspx.cs" Inherits="SAR.frmBeneficiarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="app">
        <div class="page-header page-header-default">
			<div class="page-header-content">
				<div class="page-title">
					<h4><i class="icon-arrow-left52 position-left"></i> <span class="text-semibold">Capturar </span>Beneficiarios</h4>
			    </div>
            </div>
        </div>
        <div class="container-fluid"  ng-controller="benCtrl">
            <!-- inicio de datos generales --> 
            <div class="row">
                <div class="col-xs-12 caja" style="margin-bottom:5px;">
                    <h5><b>Datos Generales</b></h5>
                </div>
                <div class="col-xs-12 col-sm-4 caja">
                    <div class="col-xs-12 first">
                        <p>CURP<small class="required-mark" ng-if="requerido == true">***</small></p>
                        <input  class="form-control" type="text" value="" name="txtcurp" ng-model="ngCurp" required/>
                    </div>
                    <div class="col-xs-12">
                        <p>UPP</p>
                        <input class="form-control" type="text" value="" name="txtupp" ng-model="ngUpp"/>
                    </div>
                    <div class="col-xs-12">
                        <p>MUNICIPIO</p>
                        <select class="form-control" name="cbomun" ng-model="municipio" ng-options="municipio.NOMBRE for municipio in municipios" ng-change="setLocalidad(municipio.CVE_MPIO)" >
                            <option value="">-- Selecciona Municipio --</option>
                        </select>
                        <%--{{municipio.CVE_MPIO}}--%>
                    </div>
                    <div class="col-xs-12 last">
                        <p>LOCALIDAD</p>
                         <select class="form-control" ng-model="localidad" ng-options="localidad.LOCALIDAD for localidad in localidades" ng-init="Seleccione" name="cboloc">
                             <option value="">-- Selecciona Localidad --</option>
                         </select>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-4 caja">
                    <div class="col-xs-12 first">
                        <p>APELLIDO PATERNO<small class="required-mark" ng-if="requerido == true">***</small></p>
                        <input class="form-control" type="text" value="" ng-model="ngPaterno" name="txtpaterno" required />
                    </div>
                    <div class="col-xs-12">
                        <p>APELLIDO MATERNO</p>
                        <input class="form-control" type="text" value="" ng-model="ngMaterno" name="txtmaterno" />
                    </div>
                    <div class="col-xs-12">
                        <p>NOMBRE(S)<small class="required-mark" ng-if="requerido == true">***</small></p>
                        <input class="form-control" type="text" value="" ng-model="ngNombre" name="txtnombre" required />
                    </div>
                    <div class="col-xs-12 last">
                        <p>ESTADO CIVIL</p>
                         <select class="form-control" name="cboedocivil" ng-model="ngCivil">
                             <option value="0">-- Selecciona --</option>
                             <option value="SOLTERO">SOLTERO</option>
                             <option value="CASADO">CASADO</option>
                             <option value="DIVORCIADO">DIVORCIADO</option>
                             <option value="VIUDO">VIUDO</option>
                             <option value="UNIÓN LIBRE">UNIÓN LIBRE</option>
                             <option value="COMPROMETIDO">COMPROMETIDO</option>
                         </select>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-4 caja">
                    <div class="col-xs-12 first">
                        <p>DOMICILIO<small class="required-mark" ng-if="requerido == true">***</small></p>
                        <input class="form-control" type="text" value="" ng-model="ngDomicilio"name="txtdomicilio" />
                    </div>
                    <div class="col-xs-12">
                        <p>OCUPACIÓN</p>
                        <input class="form-control" type="text" value="" ng-model="ngOcupacion" name="txtocupacion" />
                    </div>
                    <div class="col-xs-12 ">
                        <p>TELÉFONO</p>
                        <input class="form-control" type="tel" value="" ng-model="ngTel" name="txttel"  />
                    </div>
                    <div class="col-xs-12 last">
                        <p>OBSERVACIONES</p>
                         <input class="form-control" type="text" value="" ng-model="ngObs" name="txtobvs" required/>
                    </div>
                </div>
            </div>
            <!-- fin de datos generales --> 
            <!-- inicio de datos nacimiento --> 
            <div class="row">
                <div class="col-xs-12">
                    <div class="col-xs-12 caja titulo">
                        <h5><b>Datos de Nacimiento</b></h5>
                    </div>
                    <div class="col-xs-12 caja">
                        <div class="col-xs-4 first last">
                            <p>FECHA<span class="required-mark" ng-if="requerido == true">***</span></p>
                            <input class="form-control" type="date" ng-model="ngfnac" placeholder="dd/mm/yyyy" maxlenght="10" value="" name="txtfecha" />
                        </div>
                        <div class="col-xs-4 first last">
                            <p>ESTADO</p>
                            <select class="form-control" ng-model="estado" ng-options="estado.ESTADO for estado in estados" type="text" value="" name="txtestado">
                                <option value="">-- Selecciona Estado --</option>
                            </select>
                        </div>
                        <div class="col-xs-4 first last">
                            <p>GÉNERO</p>
                            <select class="form-control" name="cbogenero" ng-model="ngGenero">
                                <option value="0">-- Selecciona --</option>
                                <option value="FEMENINO">FEMENINO</option>
                                <option value="MASCULINO">MASCULINO</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
            <!-- fin de datos nacimiento -->
            <div class="row">
                <div class="col-xs-12 ">
                    <div class="col-xs-12 col-sm-6 first text-left">
                        <p  class="required-mark" ng-if="requerido == true">*** Campos requeridos</p>
                    </div>
                     <div class="col-xs-12 col-sm-3 first ">
                        <input  class="btn btn-warning btn-block" value="Reiniciar" ng-click="reiniciar()" name="btnreiniciar"/>
                    </div>
                    <div class="col-xs-12 col-sm-3 first">
                        <input type=""  class="btn btn-success btn-block" value="Guardar" ng-click="insertBeneficiario()" />
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
