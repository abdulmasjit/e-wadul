import { Remote, remoteEnum } from '~/data/source/remote/remote'

const baseUrl = 'pengaduan'

const addPengaduan = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)
const editPengaduan = (id: number, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}`, data)
const deletePengaduan = (id: number) => new Remote(remoteEnum.delete, `${baseUrl}/${id}`)
const fetchPengaduan = (filter: any = '') => new Remote(remoteEnum.get, `${baseUrl}${filter}`)
const fetchOnePengaduan = (id: number) => new Remote(remoteEnum.get, `${baseUrl}/${id}`)

export {
  fetchPengaduan,
  addPengaduan,
  fetchOnePengaduan,
  editPengaduan,
  deletePengaduan
}
