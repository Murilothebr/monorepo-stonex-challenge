"use client"

import { IconTrash } from '@tabler/icons-react';
import { Card, Image, Text, Group, Badge, Button, ActionIcon } from '@mantine/core';
import classes from '../styles/ProductCard.module.css';
import { useEffect, useState } from 'react';
import { fetchCardData } from '../services/apiService';

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
            <ActionIcon variant="default" radius="md" size={36}>
              <IconTrash className={classes.like} stroke={1.5} />
            </ActionIcon>
          </Group>
        </Card>
      ))}
    </div>
  );
}
