import { Remote, remoteEnum } from '@/data/source/remote/remote'

const baseUrl = 'Auth'

const login = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)

export {
  login
}
