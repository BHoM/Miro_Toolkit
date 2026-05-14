# Miro Toolkit for BHoM

The Miro Toolkit connects the [Buildings and Habitats object Model (BHoM)](https://bhom.xyz) to [Miro](https://miro.com), a collaborative online whiteboard platform.

## Purpose

Design and engineering workflows increasingly rely on shared visual spaces for planning, coordination, and communication. This toolkit allows BHoM workflows to read and write content on Miro boards, enabling teams to:

- Generate boards and populate them with data from BHoM models
- Create sticky notes, shapes, and text items from a script or Grasshopper definition
- Read board content back into BHoM for further processing
- Delete boards and items as part of automated workflows

This opens up possibilities such as placing analysis results on a board automatically, generating visual diagrams from structural data, or keeping a Miro board in sync with a BHoM model.

## Getting an API Token

To use this toolkit you need a Miro API access token. This is a personal credential that authorises requests on your behalf.

1. Log in to your Miro account at [miro.com](https://miro.com).
2. Go to **Profile Settings** and open the **Apps** section, or visit [miro.com/app/settings/user-profile/apps](https://miro.com/app/settings/user-profile/apps) directly.
3. Create a new app and copy the access token it provides.
4. Pass this token into the `MiroAdapter` component when setting up your BHoM definition. It is never stored in code.

Keep your token private. Do not share it or commit it to version control.

## Supported Operations

| Operation | Type to use |
|---|---|
| Create a board | Push `MiroBoard` |
| List boards | Pull `MiroBoard` |
| Delete a board | Remove `MiroBoard` |
| Create a sticky note | Push `MiroStickyNote` |
| Create a shape | Push `MiroShape` |
| Create a text item | Push `MiroText` |
| List items on a board | Pull `MiroItem` with `MiroConfig.BoardId` set |
| Get a specific item | Pull with item ID and `MiroConfig.BoardId` set |
| Delete an item | Remove with `MiroConfig.BoardId` set |

## What is BHoM?

BHoM (Buildings and Habitats object Model) is an open-source framework for sharing data and methods across disciplines in the built environment. More information is available at [bhom.xyz](https://bhom.xyz).

## Licence

This toolkit is licensed under the GNU Lesser General Public Licence v3.0. See [LICENSE](LICENSE) for details.
