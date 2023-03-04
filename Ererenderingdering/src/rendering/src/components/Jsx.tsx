/**
 * A simple Content Block component, with a heading and rich text block.
 * This is the most basic building block of a content site, and the most basic
 * JSS component that's useful.
 */
import React from 'react';
import {
  Image as JssImage,
  Link as JssLink,
  ImageField,
  Field,
  LinkField,
  Text,
  useSitecoreContext,
  RichText,
} from '@sitecore-jss/sitecore-jss-nextjs';

import JsxParser from 'react-jsx-parser';

const Jsx = (props): JSX.Element => {
  const { sitecoreContext } = useSitecoreContext();

  return (
    <JsxParser
      components={{ Text, JssImage, JssLink, RichText }}
      bindings={{ props, sitecoreContext }}
      jsx={props.fields.VariantJsx}
    />
  );
};

export default Jsx;
