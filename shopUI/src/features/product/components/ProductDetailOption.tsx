import { Button } from 'antd';
import { AddCartIcon } from 'components/Icons';
import React from 'react';
import { useTranslation } from 'react-i18next';

interface ProductDetailOptionProps {
  handleBuy: () => void;
  addToCart: () => void;
}

const ProductDetailOption: React.FunctionComponent<ProductDetailOptionProps> = ({
  handleBuy,
  addToCart,
}) => {
  const { t } = useTranslation();
  return (
    <div className="product-detail__options">
      <Button onClick={addToCart} type={'default'} size={'large'} danger>
        <AddCartIcon />
        {t('product.detail.addCart')}
      </Button>
      <Button onClick={handleBuy} type={'primary'} size={'large'} danger>
        {t('product.detail.buy_now')}
      </Button>
    </div>
  );
};

export default ProductDetailOption;
