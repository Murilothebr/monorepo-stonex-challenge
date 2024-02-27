"use client"

import { zodResolver } from '@hookform/resolvers/zod';
import { Box, Button, Group, TextInput, rem, Notification } from "@mantine/core";
import { useForm } from 'react-hook-form';
import { z } from "zod";
import { PostCard } from '../../services/apiService';
import { IconX, IconCheck } from '@tabler/icons-react';
import { useEffect, useState } from 'react';
import { redirect } from 'next/dist/server/api-utils';
import { useRouter } from 'next/navigation';

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

const productSchema = z.object({
  name: z.string().min(1, 'Name is required'),
  sku: z.string().min(5).max(20, 'SKU must be between 5 and 20 characters'),
  price: z.string().regex(/^\d+(\.\d{1,2})?$/, 'Price must be a valid number'),
  stock: z.string().regex(/^\d+$/, 'Stock must be a valid number'),
  description: z.string().min(1, 'Description is required'),
  imageUrls: z.string().min(1, 'At least one Image URL is required'),
  tags: z.string().min(1, 'At least one tag is required'),
  sessions: z.string().min(1, 'At least one session is required'),
});

export default function CreateProduct() {
  const [notification, setNotification] = useState<{
    icon: string; message: string, color: string
  } | null>(null);
  const [data, setData] = useState<CardData[]>([]);

  const { register, handleSubmit, formState: { errors } } = useForm({
    resolver: zodResolver(productSchema)
  });
  const { push } = useRouter();

  const onSubmit = (data: any) => {
    const convertedData: CardData = {
      name: data.name,
      sku: data.sku,
      price: data.price,
      stock: data.stock,
      description: data.description,
      imageUrls: data.imageUrls ? [data.imageUrls] : [],
      tags: data.tags ? [data.tags] : [],
      sessions: data.sessions ? [data.sessions] : [],
      productId: "",
      inStock: true
    };
  
    console.log(convertedData);
  
    try {
      const error = PostCard(convertedData); // Await PostCard
  
      if (error instanceof Error) {
        if (error.message && error.message.includes('Conflict Error: Sku must be unique')) {
          setNotification({ icon: 'xIcon', message: 'The resource already exists', color: 'red' });
          console.error('Unhandled error:', error);
          
        } else {
          setNotification({ icon: 'xIcon', message: 'An error occurred', color: 'red' });
          console.error('Unhandled error:', error);
        }
      } else {

        setNotification({ icon: 'checkIcon', message: 'Product created successfully', color: 'teal' });
        setTimeout(() => {
          push('/');
        }, 2500);
      }
    } catch (error) {
      setNotification({ icon: 'xIcon', message: 'An error occurred', color: 'red' });
      console.error('Unhandled error:', error);
    }
  };

  return (

    <>
      {<Box maw={340} mx="auto">
        <form onSubmit={handleSubmit(onSubmit)}>
          <TextInput mt={20} label="Name" placeholder="Name" {...register('name')} />
          {errors.name && <p style={{ color: "red" }}>{errors.name.message?.toString()}</p>}
          <TextInput mt={20} label="Sku" placeholder="Sku" {...register('sku')} />
          {errors.sku && <p style={{ color: "red" }}>{errors.sku.message?.toString()}</p>}
          <TextInput mt={20} type="number" label="Price" placeholder="Price" {...register('price')} />
          {errors.price && <p style={{ color: "red" }}>{errors.price.message?.toString()}</p>}
          <TextInput mt={20} type="number" label="Stock" placeholder="Stock" {...register('stock')} />
          {errors.stock && <p style={{ color: "red" }}>{errors.stock.message?.toString()}</p>}
          <TextInput mt={20} label="Description" placeholder="Description" {...register('description')} />
          {errors.description && <p style={{ color: "red" }}>{errors.description.message?.toString()}</p>}
          <TextInput mt={20} label="Image Url" placeholder="Image Url" {...register('imageUrls')} />
          {errors.imageUrls && <p style={{ color: "red" }}>{errors.imageUrls.message?.toString()}</p>}
          <TextInput mt={20} label="Tags" placeholder="Tags" {...register('tags')} />
          {errors.tags && <p style={{ color: "red" }}>{errors.tags.message?.toString()}</p>}
          <TextInput mt={20} label="Sessions" placeholder="Sessions" {...register('sessions')} />
          {errors.sessions && <p style={{ color: "red" }}>{errors.sessions.message?.toString()}</p>}
          <Group justify="center" mt="xl">
            <Button type="submit">Submit Product !</Button>
          </Group>
        </form>
      </Box>}

      {notification && (
          <Notification
            title={notification.color === 'red' ? 'Error!' : 'Success!'}
            color={notification.color}
            onClose={() => setNotification(null)}
            style={{ width: '300px', height: '150px', padding: '20px', fontSize: '1.2rem', position: 'fixed', bottom: '20px', zIndex: '9999'}}
          >
            {notification.message}  
          </Notification>
        )}
    </>
  );
}