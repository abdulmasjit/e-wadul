<template>
  <div class="card-def px-5 py-5" style="">
    <div class="mb-3">
      <c-button
        variant-color="green"
        class="rounded-lg flex gap-2 items-center"
        variant="solid"
        @click="addNew()">
        <font-awesome-icon :icon="['fas', 'plus']" class=" cursor-pointer" />Tambah</c-button>
    </div>
    <div class=" grid grid-cols-3 gap-8">
      <div class="">
        <Maps :dataMaps="dataMaps" v-if="!loading"/>
      </div>
      <div class=" col-span-2">
        <DxDataGrid
          ref="refTableDeliveryItem"
          id="table-default-id"
          :column-auto-width="true"
          :allow-column-reordering="true"
          :show-column-lines="true"
          :show-row-lines="true"
          :show-borders="true"
          :row-alternation-enabled="false"
          :allow-column-resizing="false"
          :word-wrap-enabled="true"
          :data-source="dataSource"
          key-expr="id"
          no-data-text="Tidak Ada Data">
          <DxPaging :page-size="10" :enabled="true" />
          <DxFilterRow :visible="true" />
          <DxHeaderFilter :visible="true" />
          <DxPager
            :visible="true"
            :allowed-page-sizes="[5, 10, 15, 20, 25]"
            display-mode="full"
            :show-page-size-selector="true"
            :show-info="true"
            :show-navigation-buttons="true" />
          <DxColumn
            data-field="idUser"
            caption="Nama Pelapor"
            alignment="left"
            :min-width="100"
            :visible="true" />
          <DxColumn
            data-field="idJenisPengaduan"
            caption="Jenis Pengaduan"
            alignment="left"
            :visible="true" />
          <DxColumn
            data-field="idKecamatan"
            caption="Kecamatan"
            alignment="left"
            :visible="true" />
          <DxColumn
            data-field="tanggal"
            caption="Tanggal Pengaduan"
            :min-width="100"
            alignment="left"
            data-type="date"
            format="dd-MM-yyyy" />
          <DxColumn
            caption="Action"
            :visible="true"
            :min-width="100"
            cell-template="actionTemplate"
            alignment="left" />
          <template #actionTemplate="{ data }">
            <div class="flex gap-4">
              <font-awesome-icon
                class="cursor-pointer text-lg"
                :icon="['fas', 'eye']"
                style="color: #607D8B;"
                @click="edit(data.data)" />
              <font-awesome-icon
                :icon="['fas', 'trash-can']"
                class=" text-red-500 text-lg cursor-pointer"
                @click="deleteData(data.data)" />
              <!-- {{data.data.StatusPengirimanId}} -->
              <!-- <i class="pi pi-ellipsis-h text-base cursor-pointer text-black" aria:haspopup="true" aria-controls="overlay_panel"></i> -->
            </div>
          </template>
          <DxSearchPanel :visible="true" />
        </DxDataGrid>
        <DxLoadPanel
          :close-on-outside-click="false"
          :visible="loading"
          :position="position"
          :shading="true"
          shading-color="rgba(0,0,0,0.4)" />
      </div>
    </div>
  </div>
</template>

<script>
import {
  pengaduanUseCase
} from '~/domain/usecase'
import FormPengaduan from '~/views/pengaduan/FormPengaduan.vue'
import Maps from '~/components/maps/Maps.vue'

export default {
  components: {
    Maps,
    FormPengaduan
  },
  data() {
    return {
      dataSource: [],
      loading: false,
      position: {
        of: '#table-default-id'
      },
      isShowModal: false,
      dataForm: null,
      dataMaps: []
    }
  },
  mounted() {
    this.getAll()
  },
  methods: {
    addNew() {
      this.$router.push({
        name: 'e-wadol-pengaduan-tambah'
      })
      // this.dataForm = null
      // this.isShowModal = true
    },
    closeModal() {
      this.isShowModal = false
    },
    getAll() {
      this.loading = true
      pengaduanUseCase.getAll().then((res) => {
        console.log('response', res)
        if (!res.error) {
          this.dataMaps = res.result.map((x) => {
            return {
              name: x.alamat,
              lat: Number(x.latitude),
              lng: Number(x.longitude)
            }
          })
          this.dataSource = res.result
        }
        this.loading = false
      })
    },
    processDelete(data) {
      pengaduanUseCase.deleteData(data.id).then((res) => {
        if (!res.error) {
          this.$toast({
            // title: 'Account created.',
            description: 'Data berhasil dihapus',
            status: 'success',
            duration: 3000
          })
          this.getAll()
        } else {
          this.$toast({
            // title: 'Account created.',
            description: res.message,
            status: 'error',
            duration: 3000
          })
        }
      })
    },
    deleteData(data) {
      this.$swal({
        // title: 'Are you sure?',
        text: 'Apakah anda yakin menghapus pengaduan ini',
        icon: 'warning',
        showCancelButton: true,
      }).then((res) => {
        if (res.isConfirmed) {
          this.processDelete(data)
        }
      })
    },
    edit(data) {
      this.$router.push({
        name: 'e-wadol-pengaduan-detail-id',
        params: {
          id: data.id
        }
      })
    },
    submit(data) {
      console.log('data submit', data)
      pengaduanUseCase.submitData(data.id, {
        nama: data.nama
      }).then((res) => {
        if (!res.error) {
          if (data.id) {
            this.$toast({
              description: 'Data berhasil diubah',
              status: 'success',
              duration: 3000
            })
          } else {
            this.$toast({
              description: 'Data berhasil ditambah',
              status: 'success',
              duration: 3000
            })
          }
          this.getAll()
        } else {
          this.$toast({
            description: res.message,
            status: 'error',
            duration: 3000
          })
        }
      })
    }
  }
}
</script>

<style>

</style>
