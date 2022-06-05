import Vue from 'vue'
import 'devextreme/dist/css/dx.common.css'
import 'devextreme/dist/css/dx.light.css'
// import 'devextreme/dist/css/dx.greenmist.css'
// import 'devextreme/dist/css/dx.greenmist.compact.css'
import {
  DxDataGrid,
  DxColumn,
  DxGrouping,
  DxGroupPanel,
  DxSearchPanel,
  DxPaging,
  DxScrolling,
  DxColumnChooser,
  DxHeaderFilter,
  DxFilterRow,
  DxExport,
  DxPager
} from 'devextreme-vue/data-grid'
import { DxLoadPanel } from 'devextreme-vue/load-panel'

const components = {
  DxDataGrid,
  DxColumn,
  DxGroupPanel,
  DxGrouping,
  DxSearchPanel,
  DxPaging,
  DxScrolling,
  DxColumnChooser,
  DxHeaderFilter,
  DxFilterRow,
  DxExport,
  DxPager,
  DxLoadPanel
}

Object.entries(components).forEach(([name, component]) => {
  Vue.component(name, component)
})