"use client"

import { ActionIcon, Badge, Button, Card, Group, Image, Text } from '@mantine/core';
import { IconTrash } from '@tabler/icons-react';
import { useEffect, useState } from 'react';
import { fetchCardData, removeCardById } from '../services/apiService';
import classes from '../styles/ProductCard.module.css';

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

export function BadgeCardTopListing() {
  const [data, setData] = useState<CardData[]>([]);

  useEffect(() => {
    async function fetchData() {
      try {
        const cardData = await fetchCardData();
        setData(cardData);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    }

    fetchData();
  }, []);

  const handleRemoveCard = async (id: any) => {
    try {
      await removeCardById(id);
      setData(data.filter(card => card.productId !== id));
    } catch (error) {
      console.error('Error removing card:', error);
    }
  };


  return (
    <div className={classes.cardList}>
      {data.map((item, index) => (
        <Card withBorder radius="md" p="md" className={classes.card} key={index}>
          <Card.Section>
            <div className={classes.imageContainer}>
              <Image src={item.imageUrls[0]} alt={item.name} className={classes.image} />
            </div>
          </Card.Section>
          <Card.Section className={classes.section} mt="md">
            <Group justify="apart">
              <Text fz="lg" fw={500}>
                {item.name}
              </Text>
            </Group>
            <Text fz="sm" mt="xs">
              {item.description}
            </Text>
          </Card.Section>
          <Card.Section className={classes.section}>
            <Text mt="md" className={classes.tag} c="dimmed">
              Perfect for you, if you enjoy
            </Text>
            <Group gap={7} mt={5}>
              {item.tags.map((tag, tagIndex) => (
                <Badge variant="light" key={tagIndex}>
                  {tag}
                </Badge>
              ))}
            </Group>
          </Card.Section>
          <Group mt="xs">
            <Button radius="md" style={{ flex: 1 }}>
              Show details
            </Button>
            <ActionIcon
              variant="default"
              radius="md"
              size={36}
              onClick={() => handleRemoveCard(item.productId)} // Call handleRemoveCard with item id
            >
              <IconTrash className={classes.like} stroke={1.5} />
            </ActionIcon>
          </Group>
        </Card>
      ))}
    </div>
  );
}
