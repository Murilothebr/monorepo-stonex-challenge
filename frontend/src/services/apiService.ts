import axios, { AxiosResponse } from 'axios';

interface CardData {
  name: string;
  sku: string;
  price: string;
  description: string;
  imageUrls: string[];
  tags: string[];
  sessions: string[];
  productId: string;
  inStock: boolean;
  id: any;
}

export async function fetchCardData(): Promise<CardData[]> {
  try {
    const response: AxiosResponse<CardData[]> = await axios.get<CardData[]>('https://localhost:44335/Product');
    return response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
}

export async function removeCardById(id: any): Promise<void> {
  try {
    await axios.delete(`https://localhost:44335/Product/${id}`);
    console.log(`Card with ID ${id} has been removed.`);
  } catch (error) {
    console.error(`Error removing card with ID ${id}:`, error);
    throw error;
  }
}