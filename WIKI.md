# Miro Toolkit: User Guide

## Overview

The Miro Toolkit allows you to connect BHoM workflows to Miro boards. You can create boards, add content to them (sticky notes, shapes, and text items), read existing boards and their contents back into BHoM, and delete boards or items. All of this is done from within a BHoM environment such as Grasshopper.

---

## Getting Started

### Step 1: Get a Miro API Token

Before using the toolkit you need a Miro API access token. This is a personal credential tied to your Miro account.

1. Log in at [miro.com](https://miro.com).
2. Go to **Profile Settings** and open the **Apps** section, or visit [miro.com/app/settings/user-profile/apps](https://miro.com/app/settings/user-profile/apps).
3. Create a new app and copy the access token it provides.

Your token is personal. Keep it private. Do not paste it into a script file, commit it to a repository, or share it with others. Pass it directly into the adapter component each session.

### Step 2: Install the Toolkit

Build the Miro_Toolkit solution in Visual Studio. The post-build step copies the assemblies to `C:\ProgramData\BHoM\Assemblies` automatically. Once they are there, they will be available in your BHoM environment the next time it starts.

### Step 3: Create the Adapter

In your BHoM environment, place a `MiroAdapter` component. Connect your API token to the `token` input. The adapter handles all communication with the Miro API. You do not normally need to change the `baseUrl` input.

---

## Creating a Board

Use the `MiroBoard` Create component to define a new board. The inputs are:

- `name`: the name that will appear in Miro (up to 60 characters)
- `description`: an optional description (up to 300 characters)
- `teamId`: optional, places the board in a specific Miro team workspace
- `projectId`: optional, associates the board with a Miro project

Connect the board to a `Push` component along with the adapter and run it. After the push completes, the `MiroBoardId` and `ViewLink` fields on the object will be filled in automatically. Keep a note of the `MiroBoardId` as you will need it to add items to the board.

---

## Adding Items to a Board

Each item type has its own Create component. For all item types you must set the `boardId` input to the `MiroBoardId` of the target board.

After pushing any item, the `MiroItemId` field on the object will be filled in. Keep this value if you need to retrieve or delete the item later.

### Sticky Notes

Use the `MiroStickyNote` Create component. Inputs:

| Input | Description |
|---|---|
| `boardId` | The ID of the board to add the note to |
| `content` | The text to display on the note |
| `x`, `y` | Position on the board canvas (0, 0 is the centre) |
| `width` | Width of the note in pixels |
| `colour` | Background colour, chosen from a named list (see Colour Options below) |
| `shape` | `Square` or `Rectangle` |
| `style` | Optional: a `MiroStickyNoteStyle` object for fine-grained control |

### Shapes

Use the `MiroShape` Create component. Inputs:

| Input | Description |
|---|---|
| `boardId` | The ID of the board to add the shape to |
| `shapeType` | The outline of the shape (see Shape Types below) |
| `content` | Optional text label displayed inside the shape |
| `x`, `y` | Position on the board canvas |
| `width`, `height` | Dimensions in pixels |
| `style` | Optional: a `MiroShapeStyle` object for fill, border, and text settings |

### Text Items

Use the `MiroText` Create component. Inputs:

| Input | Description |
|---|---|
| `boardId` | The ID of the board to add the text to |
| `content` | The text to display |
| `x`, `y` | Position on the board canvas |
| `width` | Width of the text box in pixels |
| `style` | Optional: a `MiroTextStyle` object for colour, font size, and alignment |

---

## Reading Boards and Items

Use the `Pull` component with your adapter to retrieve data from Miro.

### Getting a List of Boards

Set the type input to `MiroBoard`. You can optionally connect a `MiroConfig` object with:

- `teamId`: filters boards to a specific Miro team
- `limit`: the maximum number of boards to return (up to 50)

The returned objects will have `MiroBoardId`, `Name`, `Description`, and `ViewLink` filled in.

### Getting Items on a Board

Set the type input to `MiroItem` (or a more specific type such as `MiroStickyNote` or `MiroShape`). You must connect a `MiroConfig` with `boardId` set to the board you want to read from.

Optional `MiroConfig` settings:

- `itemType`: filter the results by type (for example, `StickyNote`, `Shape`, `Text`, or `All`)
- `limit`: the maximum number of items to return (up to 50)

### Getting a Specific Item

Pass the `MiroItemId` of the item in the IDs input of the `Pull` component, along with a `MiroConfig` with `boardId` set. Only that item will be returned.

---

## Deleting Boards and Items

Use the `Remove` component with your adapter.

### Deleting a Board

Set the type to `MiroBoard`. Pass the `MiroBoardId` as the ID. The board and all of its content will be permanently deleted from Miro.

### Deleting an Item

Set the type to the relevant item type (`MiroStickyNote`, `MiroShape`, or `MiroText`). Pass the `MiroItemId` as the ID. You must also connect a `MiroConfig` with `boardId` set to the board the item belongs to.

---

## Position and Coordinates

Positions on a Miro board use the following coordinate system:

- (0, 0) is the centre of the canvas
- X increases to the right
- Y increases downward
- Units are device-independent pixels (dp), which correspond roughly to screen pixels at standard zoom

---

## Colour Options

Sticky note colours are chosen from a fixed list of named values:

`LightYellow`, `Yellow`, `Orange`, `LightGreen`, `Green`, `DarkGreen`, `Cyan`, `LightPink`, `Pink`, `Violet`, `Red`, `LightBlue`, `Blue`, `DarkBlue`, `Gray`, `Black`

Shape fill colours, border colours, and text colours are provided as hex colour codes, for example `#ffffff` for white or `#1a1a1a` for near-black.

---

## Shape Types

The following shape types are available for the `MiroShape` component:

`Rectangle`, `RoundRectangle`, `Circle`, `Triangle`, `Rhombus`, `Parallelogram`, `Trapezoid`, `Pentagon`, `Hexagon`, `Octagon`, `Star`, `Cross`, `Arrow`, `Callout`

---

## Using MiroConfig

`MiroConfig` is a settings object you can connect to `Pull` and `Remove` components to provide additional context. Create one using the `MiroConfig` Create component. Its inputs are:

| Input | Used for |
|---|---|
| `boardId` | Required when pulling or deleting items |
| `teamId` | Optional filter when pulling boards |
| `limit` | Controls how many results are returned per request |
| `itemType` | Filters the type of items returned when pulling items |

---

## Common Patterns

**Create a board and immediately add items to it**

Push a `MiroBoard` first, capture the resulting `MiroBoardId` from the output, then use that ID as the `boardId` input on your item Create components before pushing them.

**Read all items of one type from a board**

Use `Pull` with type `MiroStickyNote` (or another type) and a `MiroConfig` with the `boardId` set. Items of other types on the same board will be filtered out automatically.

**Clean up after testing**

Push a temporary board, use it for testing, then pass its `MiroBoardId` to a `Remove` component to delete the whole board and its contents in one step.

---

## Limitations

- The adapter creates new items each time you push. Pushing the same object twice creates two separate items in Miro. There is no built-in update operation.
- Miro applies rate limits to its API. If you push a large number of items quickly and start seeing errors, add a small pause between operations.
- Only the item types listed in this guide (sticky notes, shapes, text) are fully supported. Other item types (images, cards, frames) can be read back but are not converted into typed BHoM objects.
