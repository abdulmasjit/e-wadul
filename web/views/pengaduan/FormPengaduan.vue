<template>
  <div>
    <div>
      <ValidationObserver ref="form">
        <form @submit.prevent="submit">
          <div class="mb-5">
            <ValidationProvider
              name="Tanggal Pengaduan"
              rules="required"
              v-slot="{ errors }">
              <label class="text-body2">Tanggal Pengaduan</label>
              <c-input
                placeholder=""
                class="mt-1"
                type="date"
                focus-border-color="primary"
                :disabled="isEdit"
                v-model="date" />
              <span class="text-error">{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div class="mb-5">
            <ValidationProvider
              name="Jenis Pengaduan"
              rules="required"
              v-slot="{ errors }">
              <label class="text-body2">Jenis Pengaduan</label>
              <v-select
                label="nama"
                class="mt-1"
                :options="typeComplaintOption"
                :reduce="country => country.id"
                :disabled="isEdit"
                v-model="typeComplaint"></v-select>
              <span class="text-error">{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div class="mb-5">
            <ValidationProvider
              name="Kecamatan"
              rules="required"
              v-slot="{ errors }">
              <label class="text-body2">Kecamatan</label>
              <v-select
                label="nama"
                class="mt-1"
                :options="kecamatanOption"
                :reduce="country => country.id"
                :disabled="isEdit"
                v-model="kecamatan"></v-select>
              <span class="text-error">{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div class="mb-5">
            <Maps
              class="mb-3"
              @sendData="sendDataFromMaps"
              :dataMaps="dataMaps"
              v-if="$route.name === 'e-wadol-pengaduan-detail-id' && !loading" />
            <Maps
              class="mb-3"
              :isSearch="true"
              :dataMaps="dataMaps"
              @sendData="sendDataFromMaps"
              v-if="$route.name === 'e-wadol-pengaduan-tambah' && !loading" />
            <div class=" grid grid-cols-2 gap-8">
              <div>
                <c-input-group>
                  <c-input-left-addon>lat</c-input-left-addon>
                  <c-input
                    placeholder="Latitude"
                    focus-border-color="primary"
                    disabled
                    v-model="lat" />
                </c-input-group>
              </div>
              <div>
                <c-input-group>
                  <c-input-left-addon>lng</c-input-left-addon>
                  <c-input
                    placeholder="Longtitude"
                    focus-border-color="primary"
                    disabled
                    v-model="lng" />
                </c-input-group>
              </div>
            </div>
          </div>
          <div class="mb-5">
            <ValidationProvider
              name="Alamat"
              rules="required"
              v-slot="{ errors }">
              <label for="idAddress" class="text-body2">Alamat</label>
              <textarea id="idAddress" class="mt-1 input-primary " v-model="address" :disabled="isEdit"></textarea>
              <span class="text-error">{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div class="mb-5">
            <label class="text-body2">Keterangan</label>
            <textarea class="mt-1 input-primary " v-model="description" :disabled="isEdit"></textarea>
          </div>
        </form>
      </ValidationObserver>
    </div>
    <div class="flex gap-2 w-full justify-end">
      <c-button
        variant-color="green"
        class="rounded-lg flex gap-4 items-center"
        variant="solid"
        @click="submit">Submit</c-button>
      <c-button @click="onClose">Kembali</c-button>
    </div>
  </div>
</template>

<script>
import {
  pengaduanUseCase,
  kecamatanUseCase,
  jenisPengaduanUseCase
} from '~/domain/usecase'
import Maps from '~/components/maps/Maps.vue'
import moment from 'moment'

export default {
  name: 'FormJenisPengaduan',
  components: {
    Maps
  },
  props: {
    data: {
      default: () => null
    }
  },
  emits: ['closeModal', 'reloadData'],
  data() {
    return {
      name: null,
      date: moment().format('YYYY-MM-DD'),
      kecamatan: null,
      typeComplaint: null,
      kecamatanOption: [],
      typeComplaintOption: [],
      address: '',
      description: null,
      lat: '',
      lng: '',
      isEdit: true,
      dataMaps: [],
      loading: false
    }
  },
  created() {
    this.getDataForm()
  },
  mounted() {
    this.getKecamatan()
    this.getTypeComplaint()
  },
  beforeUnmount() {
    console.log('beforeUnmount')
  },
  unmounted() {
    console.log('onmouteddd')
  },
  methods: {
    onClose() {
      this.$router.push({
        name: 'e-wadol-pengaduan'
      })
    },
    getKecamatan() {
      kecamatanUseCase.getAll().then((res) => {
        if (!res.error) {
          this.kecamatanOption = res.result
        }
      })
    },
    getTypeComplaint() {
      jenisPengaduanUseCase.getAll().then((res) => {
        if (!res.error) {
          this.typeComplaintOption = res.result
        }
      })
    },
    getDataForm() {
      this.isEdit = false
      this.loading = true
      pengaduanUseCase.getDataForm(this.$route.params.id).then((res) => {
        console.log('response', res)
        if (res.data && !res.data.error) {
          this.isEdit = true
          console.log('masuk sini')
          this.date = moment(res.data.result.tanggal).format('YYYY-MM-DD')
          this.kecamatan = res.data.result.idKecamatan
          this.typeComplaint = res.data.result.idJenisPengaduan
          this.lng = res.data.result.longitude
          this.lat = res.data.result.latitude
          this.address = res.data.result.alamat
          this.description = res.data.result.keterangan
          this.dataMaps.push({
            name: res.data.result.alamat,
            lat: Number(res.data.result.latitude),
            lng: Number(res.data.result.longitude)
          })
        }
        this.loading = false
      })
    },
    processSubmit() {
      pengaduanUseCase.submitData(null, {
        tanggal: this.date,
        idJenisPengaduan: this.typeComplaint,
        idKecamatan: this.kecamatan,
        longitude: this.lng.toString(),
        latitude: this.lat.toString(),
        alamat: this.address,
        keterangan: this.description,
        idUser: this.$store.state.appActiveUser.id
      }).then((res) => {
        if (!res.error) {
          this.$toast({
            description: 'Data berhasil ditambah',
            status: 'success',
            duration: 3000
          })
          this.$router.push({
            name: 'e-wadol-pengaduan'
          })
        } else {
          this.$toast({
            description: res.message,
            status: 'error',
            duration: 3000
          })
        }
      })
    },
    sendDataFromMaps(val) {
      this.address = val.location
      document.getElementById('idAddress').value = this.address
      this.lat = val.lat
      this.lng = val.lng
    },
    submit() {
      this.$refs.form.validate().then((success) => {
        console.log('isSuccess', success)
        if (success) {
          this.processSubmit()
        }
      })
    }
  }
}
</script>

<style>

</style>
