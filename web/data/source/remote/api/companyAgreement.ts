import { Remote, remoteEnum } from '@/data/source/remote/remote'

const baseUrl = 'CompanyAgreement'

const fetchAllCompanyAgreement = (filter = '') => new Remote(remoteEnum.get, `${baseUrl}${filter}`)
const fetchOneCompanyAgreement = (id: number) => new Remote(remoteEnum.get, `${baseUrl}/${id}`)
const addCompanyAgreement = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)
const editCompanyAgreement = (id: any, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}`, data)
const deleteCompanyAgreement = (id: any) => new Remote(remoteEnum.delete, `${baseUrl}/${id}`)
const changeIsActiveCompanyAgreement = (id: number, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}/isActive`, data)

export {
  fetchAllCompanyAgreement,
  fetchOneCompanyAgreement,
  addCompanyAgreement,
  editCompanyAgreement,
  deleteCompanyAgreement,
  changeIsActiveCompanyAgreement
}
