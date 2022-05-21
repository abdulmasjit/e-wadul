import { Remote, remoteEnum } from '@/data/source/remote/remote'

const baseUrl = 'Company'

const fetchAllCompany = (filter = '') => new Remote(remoteEnum.get, `${baseUrl}${filter}`)
const fetchOneCompany = (id: number) => new Remote(remoteEnum.get, `${baseUrl}/${id}`)
const addCompany = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)
const editCompany = (id: any, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}`, data)
const deleteCompany = (id: any) => new Remote(remoteEnum.delete, `${baseUrl}/${id}`)
const changeIsActiveCompany = (id: number, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}/isActive`, data)

export {
  fetchAllCompany,
  fetchOneCompany,
  addCompany,
  editCompany,
  deleteCompany,
  changeIsActiveCompany
}
