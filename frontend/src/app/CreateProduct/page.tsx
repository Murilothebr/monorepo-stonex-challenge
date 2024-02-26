"use client"

import { Box, Button, Group, TextInput } from "@mantine/core";
import { useForm } from '@mantine/form';
import { z } from "zod";
import { PostCard } from '../../services/apiService';

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

const productSchema = z.
  object({
    Name: z.string().min(1, 'Name is required'),
    SKU: z.string().min(5).max(20, 'SKU must be between 5 and 20 characters'),
    Price: z.string().regex(/^\d+(\.\d{1,2})?$/).min(0, 'Price must be greater than or equal to zero'),
    Stock: z.number().min(0, 'Stock must be a non-negative number'),
    Description: z.string().min(1, 'Description is required'),
    ImageUrls: z.array(z.string()).min(1, 'At least one Image URL is required'),
    Tags: z.array(z.string()).min(1, 'At least one tag is required'),
    Sessions: z.array(z.string()).min(1, 'At least one session is required'),
  });


export default function CreateProduct() {

  const form = useForm({
    initialValues: {
      name: '',
      sku: '',
      price: "",
      stock: "",
      description: "",
      imageUrls: "",
      tags: "",
      sessions: ""
    },
  });

  return (
    <Box maw={340} mx="auto">
      <TextInput  mt={20} label="Name" placeholder="Name" {...form.getInputProps('name')} />
      <TextInput  mt={20} label="Sku" placeholder="Sku" {...form.getInputProps('sku')} />
      <TextInput  mt={20} type="number" label="Price" placeholder="Price" {...form.getInputProps('price')} />
      <TextInput  mt={20} type="number" label="Stock" placeholder="Stock" {...form.getInputProps('stock')} />
      <TextInput  mt={20} label="Description" placeholder="Description" {...form.getInputProps('description')} />
      <TextInput  mt={20} label="ImageUrls" placeholder="ImageUrls" {...form.getInputProps('imageUrls')} />
      <TextInput  mt={20} label="Tags" placeholder="Tags" {...form.getInputProps('tags')} />
      <TextInput  mt={20} label="Sessions" placeholder="Sessions" {...form.getInputProps('sessions')} />

      <Group justify="center" mt="xl">
        <Button
          onClick={()  =>
           {
            const newCardData: CardData = {
              name: form.values.name,
              sku: form.values.sku,
              price: form.values.price,
              stock: form.values.stock,
              description: form.values.description,
              imageUrls: [form.values.imageUrls],
              tags: [form.values.tags],
              sessions: [form.values.sessions],
              productId: "",
              inStock: true
            };

            console.log(newCardData)
            PostCard(newCardData)
           }
          }
        >
          Submit Product !
        </Button>
      </Group>
    </Box>
  );
}