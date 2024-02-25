"use client"

import { IconTrash } from '@tabler/icons-react';
import { Card, Image, Text, Group, Badge, Button, ActionIcon } from '@mantine/core';
import classes from '../styles/ProductCard.module.css';
import { useEffect, useState } from 'react';
import { fetchCardData } from '../api/apiService'; // Import the API service

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

export function BadgeCardTopListingList() {
  const [data, setData] = useState<CardData[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const apiData = await fetchCardData();
        if (apiData) {
          const newData: CardData[] = apiData.map(item => ({
            name: item.name,
            sku: item.sku,
            image: item.image,
            title: item.title,
            price: item.price,
            description: item.description,
            tags: item.tags,
            badges: item.badges
          }));
          setData(newData);
        } else {
          console.error('Empty API response');
        }
      } catch (error) {
        console.error('Error fetching card data:', error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className={classes.cardList}>
      {data.map((item, index) => (
        <BadgeCardTopListing key={index} data={item} />
      ))}
    </div>
  );
  
}

export function BadgeCardTopListing({ data }: { data: CardData }) {
  const { image, title, description, badges } = data;
  const features = badges.map((badge) => (
    <Badge variant="light" key={badge.tag}>
      {badge.tag}
    </Badge>
  ));

  return (
    <Card withBorder radius="md" p="md" className={classes.card}>
      <Card.Section>
        <Image src={image} alt={title} height={180} />
      </Card.Section>
      <Card.Section className={classes.section} mt="md">
        <Group justify="apart">
          <Text fz="lg" fw={500}>
            {title}
          </Text>
          {/* Add Badge component for country */}
        </Group>
        <Text fz="sm" mt="xs">
          {description}
        </Text>
      </Card.Section>
      <Card.Section className={classes.section}>
        <Text mt="md" className={classes.tag} c="dimmed">
          Perfect for you, if you enjoy
        </Text>
        <Group gap={7} mt={5}>
          {features}
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
  );
}
