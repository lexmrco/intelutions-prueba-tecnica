<template>
  <div>
    <b-nav>
      <b-nav-item @click="$router.push({name: 'permisoAdd'})">Agregar permiso</b-nav-item>
    </b-nav>
    <b-table striped hover :items="items" :fields="fields">
      <template #cell(actions)="row">
        <b-button size="sm" variant="info" @click="$router.push({name: 'permisoDetails', params: { item: row.item }})" class="mr-1">
          Ver
        </b-button>
        <b-button size="sm" variant="danger" @click="confirmRemove(row.item)">
          Eliminar
        </b-button>
      </template>
    </b-table>
    <b-modal 
      :id="infoModal.id"
      v-model="modalShow"
      :title="infoModal.title" 
      @hide="resetInfoModal"
      @ok="remove(infoModal.rowId)"
      ok-title="Eliminar"
      ok-variant="danger"
      cancel-title="Cancelar"
      >
      {{ infoModal.content }}
    </b-modal>
  </div>
</template>

<script>
import { Component, Vue, Prop } from 'vue-property-decorator'
import { getModule } from 'vuex-module-decorators'
import Services from '@/services/'

@Component
export default class Home extends Vue {
  
  alertMessage = ''
  loading = false
  totalClientes = 0
  modalShow = false
  infoModal = {
    id: 'info-modal',
    title: 'Eliminar',
    content: '',
    rowId: 0
  }
  items = [
          { id: 1, nombreEmpleado: 'Dickerson', apellidosEmpleado: 'Macdonald', tipoPermisoId: 1, tipoPermisoDescripcion: "Urgencia", fecha: "11/11/2020" },
          { id: 2, nombreEmpleado: 'Larsen', apellidosEmpleado: 'Shaw', tipoPermisoId: 2, tipoPermisoDescripcion: "Cita médica", fecha: "11/11/2020" },
          { id: 3, nombreEmpleado: 'Geneva', apellidosEmpleado: 'Wilson', tipoPermisoId: 3, tipoPermisoDescripcion: "Compensatorio", fecha: "11/11/2020" },
          { id: 4, nombreEmpleado: 'Jami', apellidosEmpleado: 'Carney', tipoPermisoId: 2, tipoPermisoDescripcion: "Cita médica", fecha: "11/11/2020" }
        ]
  fields = [
    { key: 'nombreEmpleado', label: 'Nombre', sortable: true, sortDirection: 'desc' },
    { key: 'apellidosEmpleado', label: 'Apellidos', sortable: true },
    { key: 'tipoPermisoDescripcion', label: 'Tipo permiso', sortable: true },
    { key: 'fechaPermiso', label: 'Fecha', sortable: true },
    { key: 'actions', label: 'Acciones' }
  ]

  mounted () {
    this.loading = false
    this.getItems()
  }

  confirmRemove(item) {
    this.modalShow = !this.modalShow
    this.infoModal.rowId = item.id
    this.infoModal.content = `Está seguro que desea eliminar el registro: Empleado '${item.nombreEmpleado} ${item.apellidosEmpleado}'?`
  }

  getItems() {
    Services.permisoService.getItems().then((response) => {
      const { data } = response
      this.items = data
    }).catch((e) => {
      this.alertMessage = 'Problema al cargar los datos'
      console.log(e)
    })
  }

  remove(id){
    Services.permisoService.deleteItem(id).then((response) => {
        this.getItems()
      }).catch((e) => {
        this.alertMessage = 'Problema al eliminar'
        console.log(e.response)
      })
  }

  resetInfoModal() {
    this.infoModal.content = ''
    this.infoModal.rowId = 0
  }
}
</script>
