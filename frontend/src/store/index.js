import Vue from 'vue'
import Vuex from 'vuex'
import { ProductoStore } from './producto'

Vue.use(Vuex)

const store = new Vuex.Store({
  modules: {
    producto: ProductoStore
  }
})

export default store
