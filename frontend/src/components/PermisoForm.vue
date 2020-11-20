<template>
  <div>
    <b-card :title="this.cardTitle " >
      <b-form v-on:submit.prevent="onSubmit" @reset="onReset">
        <b-form-group
          id="input-group-1"
          label="Nombre empleado:"
          label-for="input-1"
        >
          <b-form-input
            id="input-1"
            v-model="permiso.nombreEmpleado"
            required
            placeholder="Nombre empleado"
            :readonly="readonly" 
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Apellido empleado:" label-for="input-2">
          <b-form-input
            id="input-2"
            v-model="permiso.apellidosEmpleado"
            required
            placeholder="Apellidos"
            :readonly="readonly"
          ></b-form-input>
        </b-form-group> 

        <b-form-group id="input-group-3" label="Tipo de permiso:" label-for="input-3">
          <b-form-select
            id="input-3"
            v-model="permiso.tipoPermisoId"
            :options="tiposPermisos"
            required
            :disabled="readonly"
          ></b-form-select>
        </b-form-group>

        <b-form-group id="input-group-3" label="Fecha permiso:" label-for="input-3">
          <b-form-datepicker 
            id="datepicker1" 
            v-model="fecha" 
            class="mb-2"
            @context="onChangeFecha"
            :readonly="readonly"
            required
            placeholder="Ingrese una fecha ..."
            ></b-form-datepicker>
        </b-form-group>

        <b-form-group id="input-group-3" label="Hora permiso:" label-for="input-3">
          <b-form-timepicker
            id="timepicker1" 
            v-model="time" 
            class="mb-2"
            @context="onChangeFecha"
            :readonly="readonly"
            placeholder="Ingrese una hora ..."
            required
            ></b-form-timepicker>
        </b-form-group>
        <b-alert v-if="alertMessage" variant="danger" show>{{alertMessage}}</b-alert>
        <b-button v-if="type==='add' || type==='edit'" type="submit" variant="primary">Guardar</b-button>
        <b-button v-if="type==='add'" type="reset" variant="danger">Limpiar</b-button>
      </b-form>
      <b-button v-if="type==='read'" type="button" @click="$router.push({name: 'permisoEdit', params: { item: permiso }})" variant="primary">Modificar</b-button>
    </b-card>
  </div>
</template>

<script>
import { Component, Vue, Prop } from 'vue-property-decorator'
import { getModule } from 'vuex-module-decorators'
import Services from '@/services/'
import moment from 'moment';

@Component
export default class PermisoForm extends Vue {
  @Prop({ required: false }) data
  @Prop({ required: true }) type
  
  cardTitle = ''
  alertMessage = ''
  loading = false
  createForm = true
  updateForm = false
  tiposPermisos = []
  permiso = { id: null, nombreEmpleado: '', apellidosEmpleado: '', tipoPermisoId: null, tipoPermisoDescripcion: '', fechaPermiso: '' }
  readonly = true
  fecha = ''
  time = ''

  mounted () {
    this.getTiposPermisos()
    if(this.data){
      this.permiso = this.data 
    }
    if(this.type === 'add'){
        this.cardTitle = 'Agregar permiso'
        this.readonly = false
    } else if (this.type === 'read') {
      this.cardTitle = 'Detalle permiso'
    } else {
      this.cardTitle = 'Editar permiso'
      this.readonly = false
    }
    this.fecha = moment(this.permiso.fechaPermiso).format('YYYY-MM-DD')
    this.time = moment(this.permiso.fechaPermiso).format('HH:mm')
    this.loading = false
  }

  getTiposPermisos() {
    Services.tipoPermisoService.getSelectListItems().then((response) => {
      const { data } = response
      this.tiposPermisos = data
      this.tiposPermisos.push({ value: null, text: 'Seleccione un tipo de permiso...' })
    }).catch((e) => {
      this.alertMessage = 'Problema al cargar los datos'
      console.log(e)
    })
  }

  onSubmit() {
    if(this.type === 'add') {
      Services.permisoService.postItem(this.permiso).then((response) => {
        this.$router.push({name: 'home'})
      }).catch((e) => {
        this.alertMessage = 'Problema al guardar los datos'
        console.log(e.response)
      })
    } else if (this.type === 'edit') {
      Services.permisoService.putItem(this.permiso).then((response) => {
        this.$router.push({name: 'home'})
      }).catch((e) => {
        this.alertMessage = 'Problema al guardar los datos'
        console.log(e.response)
      })
    }
  }

  onChangeFecha (){
    this.permiso.fechaPermiso = moment(this.fecha + " " + this.time).format('YYYY-MM-DD HH:mm')
  }

  onReset(){

  }
}
</script>
