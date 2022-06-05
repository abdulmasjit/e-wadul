import { Remote, remoteEnum } from '~/data/source/remote/remote'

const baseUrl = 'kecamatan'

const addKecamatan = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)
const editKecamatan = (id: number, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}`, data)
const deleteKecamatan = (id: number) => new Remote(remoteEnum.delete, `${baseUrl}/${id}`)
const fetchKecamatan = (filter: any = '') => new Remote(remoteEnum.get, `${baseUrl}${filter}`)
const fetchOneKecamatan = (id: number) => new Remote(remoteEnum.get, `${baseUrl}/${id}`)

export {
  fetchKecamatan,
  addKecamatan,
  fetchOneKecamatan,
  editKecamatan,
  deleteKecamatan
}
