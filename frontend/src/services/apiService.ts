import axios, { AxiosResponse } from 'axios';

interface CardData {
  name: string;
  sku: string;
  price: string;
  stock: string;
  description: string;
  imageUrls: string[];
  tags: string[];
  sessions: string[];
  productId: string;
  inStock: boolean;
}

export async function fetchCardData(): Promise<CardData[]> {
  try {
    const response: AxiosResponse<CardData[]> = await axios.get<CardData[]>('http://localhost:44335/Product');
    return response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
}

export async function PostCard(cardData: CardData): Promise<void> {
  try {
    const response = await axios.post<CardData>('http://localhost:44335/Product', cardData);
    console.log('Response data:', response.data);
  } catch (error) {
    console.error('Error fetching data:', error);
    throw error;
  }
}

export async function removeCardById(id: any): Promise<void> {
  try {
    await axios.delete(`http://localhost:44335/Product/${id}`);
    console.log(`Card with ID ${id} has been removed.`);
  } catch (error) {
    console.error(`Error removing card with ID ${id}:`, error);
    throw error;
  }
}