"use client"

import { ActionIcon, Badge, Button, Card, Group, Image, Text, Notification, rem } from '@mantine/core';
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
  const [notification, setNotification] = useState<{
    icon: string; message: string, color: string
  } | null>(null);
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
      setNotification({ icon: 'checkIcon', message: 'Card removed successfully', color: 'teal' });
    } catch (error) {
      console.log(error)
      setNotification({ icon: 'xIcon', message: 'Error removing card', color: 'red' });
    }
  };


  return (
    <>
      {
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
                <Text fz="sm" mt="xs" className={classes.description}>
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
      }


      {notification && (
        <Notification
          title={notification.color === 'red' ? 'Error!' : 'Success!'}
          color={notification.color}
          onClose={() => setNotification(null)}
          style={{ width: '300px', height: '150px', padding: '20px', fontSize: '1.2rem', position: 'fixed', bottom: '20px', zIndex: '9999' }}
        >
          {notification.message}
        </Notification>
      )}
    </>
  );
}
