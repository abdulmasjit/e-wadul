import axios from 'axios'

const API_URL = process.env.apiUrl
const axl = axios.create({
  baseURL: API_URL,
  // withCredentials: true,
  headers: {
    'Content-Type': 'application/json; charset=utf-8',
    Accept: '*/*',
  },
})

axl.interceptors.request.use((config: any) => config, (error: any) => Promise.reject(error))

axl.interceptors.response.use((response: any) => response, (error: any) => Promise.reject(error))

export default axl
