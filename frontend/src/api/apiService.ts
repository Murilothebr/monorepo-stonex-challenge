import axios, { AxiosResponse } from 'axios';

interface ApiResponse {
  data: CardData[];
}

interface CardData {
  name: string;
  sku: string;
  image: string;
  title: string;
  price: string;
  description: string;
  tags: string;
  badges: { tag: string }[];
}

export async function fetchCardData(): Promise<CardData[]> {
  try {
    const response: AxiosResponse<ApiResponse> = await axios.get<ApiResponse>('https://localhost:44335/Product');
    console.log(response)
    return response.data.data;
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
}
