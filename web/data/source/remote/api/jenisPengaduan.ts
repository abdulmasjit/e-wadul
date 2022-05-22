import { Remote, remoteEnum } from '~/data/source/remote/remote'

const baseUrl = 'jenis-pengaduan'

const addJenisPengaduan = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)
const editJenisPengaduan = (id: number, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}`, data)
const deleteJenisPengaduan = (id: number) => new Remote(remoteEnum.delete, `${baseUrl}/${id}`)
const fetchJenisPengaduan = (filter: any = '') => new Remote(remoteEnum.get, `${baseUrl}${filter}`)
const fetchOneJenisPengaduan = (id: number) => new Remote(remoteEnum.get, `${baseUrl}/${id}`)

export {
  fetchJenisPengaduan,
  addJenisPengaduan,
  fetchOneJenisPengaduan,
  editJenisPengaduan,
  deleteJenisPengaduan
}
